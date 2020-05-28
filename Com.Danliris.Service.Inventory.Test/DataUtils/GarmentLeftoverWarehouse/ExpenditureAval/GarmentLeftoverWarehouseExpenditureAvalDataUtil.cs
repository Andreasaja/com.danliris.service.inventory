﻿using Com.Danliris.Service.Inventory.Lib.Helpers;
using Com.Danliris.Service.Inventory.Lib.Models.GarmentLeftoverWarehouse.ExpenditureAval;
using Com.Danliris.Service.Inventory.Lib.Services.GarmentLeftoverWarehouse.ExpenditureAval;
using Com.Danliris.Service.Inventory.Test.DataUtils.GarmentLeftoverWarehouse.GarmentLeftoverWarehouseReceiptAvalDataUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Inventory.Test.DataUtils.GarmentLeftoverWarehouse.ExpenditureAval
{
    public class GarmentLeftoverWarehouseExpenditureAvalDataUtil
    {
        private readonly GarmentLeftoverWarehouseExpenditureAvalService Service;
        private readonly GarmentLeftoverWarehouseReceiptAvalDataUtil ReceiptAvalDataUtil;

        public GarmentLeftoverWarehouseExpenditureAvalDataUtil(GarmentLeftoverWarehouseExpenditureAvalService service, GarmentLeftoverWarehouseReceiptAvalDataUtil receiptAvalDataUtil)
        {
            Service = service;
            ReceiptAvalDataUtil = receiptAvalDataUtil;
        }

        public async Task<GarmentLeftoverWarehouseExpenditureAval>  GetNewDataFabric()
        {
            var receiptAval = await Task.Run(() => ReceiptAvalDataUtil.GetTestData());
            var DataFabric= new GarmentLeftoverWarehouseExpenditureAval
            {
                ExpenditureDate = DateTimeOffset.Now,
                ExpenditureTo = "JUAL LOKAL",
                Description = "Remark",
                AvalType="AVAL FABRIC",
                BuyerId = 1,
                BuyerCode = "BuyerCode",
                BuyerName = "BuyerName",
                Items = new List<GarmentLeftoverWarehouseExpenditureAvalItem>
                {
                    new GarmentLeftoverWarehouseExpenditureAvalItem
                    {
                        StockId = 1,
                        UnitId = 1,
                        UnitCode = "Unit",
                        UnitName = "Unit",
                        AvalReceiptNo = receiptAval.AvalReceiptNo,
                        AvalReceiptId= receiptAval.Id,
                        Quantity = receiptAval.TotalAval,
                    }
                }
            };
            return DataFabric;
        }

        public async Task<GarmentLeftoverWarehouseExpenditureAvalItem> GetNewDataItemFabric()
        {
            var receiptAval = await Task.Run(() => ReceiptAvalDataUtil.GetTestData());
            var DataFabric = new GarmentLeftoverWarehouseExpenditureAvalItem
            {
                
                        StockId = 1,
                        UnitId = 1,
                        UnitCode = "Unit",
                        UnitName = "Unit",
                        AvalReceiptNo = receiptAval.AvalReceiptNo,
                        AvalReceiptId= receiptAval.Id,
                        Quantity = receiptAval.TotalAval,
            };
            return DataFabric;
        }

        public async Task<GarmentLeftoverWarehouseExpenditureAval> GetTestDataFabric()
        {
            GarmentLeftoverWarehouseExpenditureAval data = await GetNewDataFabric();

            await Service.CreateAsync(data);

            return data;
        }

        public GarmentLeftoverWarehouseExpenditureAval CopyData(GarmentLeftoverWarehouseExpenditureAval oldData)
        {
            GarmentLeftoverWarehouseExpenditureAval newData = new GarmentLeftoverWarehouseExpenditureAval();

            PropertyCopier<GarmentLeftoverWarehouseExpenditureAval, GarmentLeftoverWarehouseExpenditureAval>.Copy(oldData, newData);

            newData.Items = new List<GarmentLeftoverWarehouseExpenditureAvalItem>();
            foreach (var oldItem in oldData.Items)
            {
                GarmentLeftoverWarehouseExpenditureAvalItem newItem = new GarmentLeftoverWarehouseExpenditureAvalItem();

                PropertyCopier<GarmentLeftoverWarehouseExpenditureAvalItem, GarmentLeftoverWarehouseExpenditureAvalItem>.Copy(oldItem, newItem);

                newData.Items.Add(newItem);
            }

            return newData;
        }
    }
}
