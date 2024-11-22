using LoadDWBigData.Data.Context;
using LoadDWBigData.Data.Entities.DwSales;
using LoadDWBigData.Data.Entities.Northwind;
using LoadDWBigData.Data.Interfaces;
using LoadDWBigData.Data.Models;
using LoadDWBigData.Data.Result;
using Microsoft.EntityFrameworkCore;

namespace LoadDWBigData.Data.Services
{
    public class LoadDwService : ILoadDwService
    {
        private readonly DbSalesContext _dbOrdersContext;
        private readonly NorthwindContext _northwindContext;
        public LoadDwService(DbSalesContext dbSalesContext, NorthwindContext northwindContext) 
        {
            _dbOrdersContext = dbSalesContext;
            _northwindContext = northwindContext;
        }

         
        public async Task<OperationResult> LoadDWH()
        {
            OperationResult result = new();
            try
            {
                await LoadDimCustomers();
                await LoadDimEmployee();
                await LoadDimShippers();
                await LoadDimCategory();
                await LoadDimProduct();
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }
        #region Dimensions
        public async Task<OperationResult> LoadDimCustomers()
        {
            OperationResult result = new();
            try
            {
                // Extract
                var customers = await _northwindContext.Customers.Select(c => new DimCliente
                {
                    ClienteId = c.CustomerId,
                    NombreCliente = c.CompanyName,
                    País = c.Country,
                    Ciudad = c.City,
                }).AsNoTracking().ToListAsync();

                // Loading
                string[] customersId = customers.Select(c => c.ClienteId).ToArray();

                await _dbOrdersContext.DimClientes.Where(c => customersId.Contains(c.ClienteId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync(); // Cleaning the entity

                await _dbOrdersContext.DimClientes.AddRangeAsync(customers);
                await _dbOrdersContext.SaveChangesAsync();
        
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = $"Error cargando los clientes: {ex.Message}";
                return result;
            }
        }

        public async Task<OperationResult> LoadDimEmployee()
        {
            OperationResult result = new();
            try
            {
                // Extracting
                var employees = await _northwindContext.Employees.Select(e => new DimEmpleado
                {
                    EmpleadoId = e.EmployeeId,
                    Nombre = e.FirstName,
                    Apellido = e.LastName,
                    Posición = e.Title
                }).AsNoTracking().ToListAsync();

                // Loading
                int[] employeesId = employees.Select(e => e.EmpleadoId).ToArray();

                await _dbOrdersContext.DimEmpleados.Where(e => employeesId.Contains(e.EmpleadoId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync(); // Cleaning

                await _dbOrdersContext.DimEmpleados.AddRangeAsync(employees);
                await _dbOrdersContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public async Task<OperationResult> LoadDimShippers()
        {
            OperationResult result = new();
            try
            {
                var shippers = await _northwindContext.Shippers.Select(s => new DimTransportistum
                {
                    TransportistaId = s.ShipperId,
                    NombreTransportista = s.CompanyName
                }).AsNoTracking().ToListAsync();

                int[] shippersId = shippers.Select(s => s.TransportistaId).ToArray();

                await _dbOrdersContext.DimTransportista.Where(s => shippersId.Contains(s.TransportistaId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.DimTransportista.AddRangeAsync(shippers);
                await _dbOrdersContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public async Task<OperationResult> LoadDimCategory()
        {
            OperationResult result = new();
            try
            {
                var categories = await _northwindContext.Categories.Select(c => new DimCategoría
                {
                    CategoríaId = c.CategoryId,
                    NombreCategoría = c.CategoryName
                }).AsNoTracking().ToListAsync();

                int[] categoriesId = categories.Select(c => c.CategoríaId).ToArray();

                await _dbOrdersContext.DimCategorías.Where(c => categoriesId.Contains(c.CategoríaId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.DimCategorías.AddRangeAsync(categories);
                await _dbOrdersContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public async Task<OperationResult> LoadDimProduct()
        {
            OperationResult result = new();
            try
            {
                var products = await _northwindContext.Products.Select(p => new DimProducto
                {
                    ProductoId = p.ProductId,
                    NombreProducto = p.ProductName,
                    PrecioUnitario = p.UnitPrice,
                    UnidadesEnStock = p.UnitsInStock,
                    CategoríaId = p.CategoryId
                }).AsNoTracking().ToListAsync();

                int[] productsId = products.Select(p => p.ProductoId).ToArray();

                await _dbOrdersContext.DimProductos.Where(p => productsId.Contains(p.ProductoId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();
                await _dbOrdersContext.DimProductos.AddRangeAsync(products);
                await _dbOrdersContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }
        #endregion

        #region Facts
        #endregion
    }
}
