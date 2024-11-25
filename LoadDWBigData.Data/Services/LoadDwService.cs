using LoadDWBigData.Data.Context;
using LoadDWBigData.Data.Entities.DwSales;
using LoadDWBigData.Data.Interfaces;
using LoadDWBigData.Data.Models;
using LoadDWBigData.Data.Result;
using Microsoft.EntityFrameworkCore;

namespace LoadDWBigData.Data.Services
{
    public class LoadDwService : ILoadDwService
    {
        private readonly DbOrdersContext _dbOrdersContext;
        private readonly NorthwindContext _northwindContext;
        public LoadDwService(DbOrdersContext dbSalesContext, NorthwindContext northwindContext)
        {
            _dbOrdersContext = dbSalesContext;
            _northwindContext = northwindContext;
        }


        public async Task<OperationResult> LoadDWH()
        {
            OperationResult result = new();
            try
            {
                //await LoadDimDate();
                //await LoadDimRegion();
                //await LoadDimCustomers();
                //await LoadDimEmployee();
                //await LoadDimShippers();
                //await LoadDimCategory();
                //await LoadDimProduct();

                //Loading Fact tables 
                //await LoadFactSales();
                //await LoadFactSalesByCategory();
                //await LoadFactSalesByRegion();
                //await LoadFactSalesByShipper();
                //await LoadFactOrdersByShippers();
                //await LoadFactProductSales();
                //await LoadFactSalesByClient();
                await LoadFactOrdersByClient();
                //await LoadFactOrders();
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
        private async Task<OperationResult> LoadDimCustomers()
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

        private async Task<OperationResult> LoadDimEmployee()
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

        private async Task<OperationResult> LoadDimShippers()
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

        private async Task<OperationResult> LoadDimCategory()
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

        private async Task<OperationResult> LoadDimProduct()
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

        private async Task<OperationResult> LoadDimRegion()
        {
            OperationResult result = new();
            try
            {
                var regions = await _northwindContext.Regions.Select(r => new DimRegión
                {
                    RegiónId = r.RegionId,
                    País = r.RegionDescription
                }).AsNoTracking().ToListAsync();

                int[] regionId = regions.Select(r => r.RegiónId).ToArray();

                await _dbOrdersContext.DimRegións.Where(r => regionId.Contains(r.RegiónId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.DimRegións.AddRangeAsync(regions);
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

        private async Task<OperationResult> LoadDimDate()
        {
            OperationResult result = new();
            try
            {
                var orderDates = await _northwindContext.Orders
                    .Select(o => o.OrderDate)
                    .Where(o => o.HasValue) // Cleaning nulls
                    .Distinct()
                    .ToListAsync();

                var dimDatesList = orderDates.Select(od => new DimFecha
                {
                    FechaId = Convert.ToInt32(od.Value.ToString("yyyyMMdd")), // Formating the date
                    Año = od.Value.Year,
                    Mes = od.Value.Month,
                    Día = od.Value.Day
                }).ToList();

                await _dbOrdersContext.DimFechas.ExecuteDeleteAsync();

                await _dbOrdersContext.DimFechas.AddRangeAsync(dimDatesList);
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

        private async Task<OperationResult> LoadFactSales()
        {
            OperationResult result = new();
            try
            {
                var sales = await _northwindContext.ViewFactData.Select(fd => new FactVenta
                {
                    ClienteId = fd.ClienteKey,
                    ProductoId = fd.ProductoKey,
                    EmpleadoId = fd.EmpleadoKey,
                    FechaId = fd.FechaKey,
                    CantidadVendida = fd.CantidadVendida,
                    PrecioUnitario = fd.PrecioUnitario,
                    TotalVenta = Convert.ToDecimal(fd.TotalVenta),
                    Descuento = Convert.ToDecimal(fd.Descuento)
                }).AsNoTracking().ToListAsync();

                await _dbOrdersContext.FactVentas
                    .ExecuteDeleteAsync();


                await _dbOrdersContext.FactVentas.AddRangeAsync(sales);

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

        private async Task<OperationResult> LoadFactSalesByCategory()
        {
            OperationResult result = new();
            try
            {
                // Extraer y agrupar datos para eliminar duplicados
                var salesByCategories = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.CategoríaKey)
                    .Select(g => new FactVentasPorCategoría
                    {
                        CategoríaId = (int)g.Key,
                        TotalVenta = g.Sum(fd => Convert.ToDecimal(fd.TotalVentaPorCategoría))
                    })
                    .ToListAsync();

                int[] salesByCategoriesId = salesByCategories.Select(s => s.CategoríaId).ToArray();

                await _dbOrdersContext.FactVentasPorCategorías.Where(s => salesByCategoriesId.Contains(s.CategoríaId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();


                await _dbOrdersContext.FactVentasPorCategorías.AddRangeAsync(salesByCategories);
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

        private async Task<OperationResult> LoadFactSalesByRegion()
        {
            OperationResult result = new();
            try
            {
                var salesByRegion = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.RegiónId)
                    .Select(g => new FactVentasPorRegión
                    {
                        RegiónId = g.Key,
                        TotalVenta = g.Sum(fd => Convert.ToDecimal(fd.TotalVentaPorRegión))
                    }).ToListAsync();

                int[] salesByRegionId = salesByRegion.Select(s => s.RegiónId).ToArray();

                await _dbOrdersContext.FactVentasPorRegións.Where(s => salesByRegionId.Contains(s.RegiónId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactVentasPorRegións.AddRangeAsync(salesByRegion);
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

        private async Task<OperationResult> LoadFactSalesByShipper()
        {
            OperationResult result = new();
            try
            {
                var salesByShippers = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.TransportistaKey)
                    .Select(g => new FactVentasPorTransportistum
                    {
                        TransportistaId = g.Key,
                        TotalVenta = g.Sum(fd => Convert.ToDecimal(fd.TotalVentaPorTransportista))
                    }).ToListAsync();

                int[] salesByShipperId = salesByShippers.Select(s => s.TransportistaId).ToArray();

                await _dbOrdersContext.FactVentasPorTransportista.Where(s => salesByShipperId.Contains(s.TransportistaId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactVentasPorTransportista.AddRangeAsync(salesByShippers);
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

        private async Task<OperationResult> LoadFactOrdersByShippers()
        {
            OperationResult result = new();
            try
            {
                var ordersByShippers = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.TransportistaKey)
                    .Select(g => new FactOrdenesPorTransportistum
                    {
                        TransportistaId = g.Key,
                        CantidadOrdenes = g.Sum(fd => fd.CantidadOrdenesPorTransportista)
                    }).ToListAsync();

                int[] ordersByShipperId = ordersByShippers.Select(s => s.TransportistaId).ToArray();

                await _dbOrdersContext.FactOrdenesPorTransportista.Where(s => ordersByShipperId.Contains(s.TransportistaId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactOrdenesPorTransportista.AddRangeAsync(ordersByShippers);
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

        private async Task<OperationResult> LoadFactProductSales()
        {
            OperationResult result = new();
            try
            {
                var productsSales = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.ProductoKey)
                    .Select(g => new FactProductosVendido
                    {
                        ProductoId = g.Key,
                        CantidadVendida = g.Sum(fd => fd.CantidadVendidaPorProducto)
                    }).ToListAsync();

                int[] productSaleId = productsSales.Select(s => s.ProductoId).ToArray();

                await _dbOrdersContext.FactProductosVendidos.Where(s => productSaleId.Contains(s.ProductoId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactProductosVendidos.AddRangeAsync(productsSales);
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

        private async Task<OperationResult> LoadFactSalesByClient()
        {
            OperationResult result = new();
            try
            {
                var ventasPorCliente = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.ClienteKey)
                    .Select(g => new FactVentasPorCliente
                    {
                        ClienteId = g.Key,
                        TotalVenta = g.Sum(fd => Convert.ToDecimal(fd.TotalVentaPorCliente))
                    }).ToListAsync();

                string[] productSaleId = ventasPorCliente.Select(s => s.ClienteId).ToArray();

                await _dbOrdersContext.FactVentasPorClientes.Where(s => productSaleId.Contains(s.ClienteId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactVentasPorClientes.AddRangeAsync(ventasPorCliente);
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

        private async Task<OperationResult> LoadFactOrdersByClient()
        {
            OperationResult result = new();
            try
            {
                var salesByCliente = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => fd.ClienteKey)
                    .Select(g => new FactOrdenesPorCliente
                    {
                        ClienteId = g.Key,
                        CantidadOrdenes = g.Sum(fd => fd.CantidadOrdenesPorCliente)
                    }).ToListAsync();

                string[] salesByClienteId = salesByCliente.Select(s => s.ClienteId).ToArray();

                await _dbOrdersContext.FactOrdenesPorClientes.Where(s => salesByClienteId.Contains(s.ClienteId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactOrdenesPorClientes.AddRangeAsync(salesByCliente);
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

        private async Task<OperationResult> LoadFactOrders()
        {
            OperationResult result = new();
            try
            {
                var orders = await _northwindContext.ViewFactData
                    .AsNoTracking()
                    .GroupBy(fd => new { fd.PedidoId, fd.EmpleadoKey, fd.ClienteKey, fd.FechaKey })
                    .Select(g => new FactPedido
                    {
                        PedidoId = g.Key.PedidoId,                  
                        EmpleadoId = g.Key.EmpleadoKey,              
                        ClienteId = g.Key.ClienteKey,                
                        FechaId = g.Key.FechaKey,                    
                        CantidadPedidos = g.Sum(fd => fd.CantidadTotalPorOrden)
                    }).ToListAsync();

                int[] ordersByShipperId = orders.Select(s => s.PedidoId).ToArray();

                await _dbOrdersContext.FactPedidos.Where(s => ordersByShipperId.Contains(s.PedidoId))
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _dbOrdersContext.FactPedidos.AddRangeAsync(orders);
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
    }
}
