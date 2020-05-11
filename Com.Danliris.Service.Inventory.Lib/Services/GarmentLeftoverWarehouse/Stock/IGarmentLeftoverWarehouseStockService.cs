﻿using Com.Danliris.Service.Inventory.Lib.Helpers;
using Com.Danliris.Service.Inventory.Lib.Interfaces;
using Com.Danliris.Service.Inventory.Lib.Models.GarmentLeftoverWarehouse.Stock;
using Com.Danliris.Service.Inventory.Lib.ViewModels.GarmentLeftoverWarehouse.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Inventory.Lib.Services.GarmentLeftoverWarehouse.Stock
{
    public interface IGarmentLeftoverWarehouseStockService : IMap<GarmentLeftoverWarehouseStock, GarmentLeftoverWarehouseStockViewModel>
    {
        ReadResponse<GarmentLeftoverWarehouseStock> Read(int page, int size, string order, List<string> select, string keyword, string filter);
        Task<int> StockIn(GarmentLeftoverWarehouseStock stock, string StockReferenceNo, int StockReferenceId, int StockReferenceItemId);
        Task<int> StockOut(GarmentLeftoverWarehouseStock stock, string StockReferenceNo, int StockReferenceId, int StockReferenceItemId);
    }
}
