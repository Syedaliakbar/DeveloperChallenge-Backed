using DeveloperChallenge.DLL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DeveloperChallenge.DLL.UnitOfWork
{
    public sealed class UnitOfWork : IDisposable
    {
        private bool disposed;
        private readonly ShippersDbContext context = new ShippersDbContext();
        private GenericRepository<Shipper> shipperRepository;
        public GenericRepository<Shipper> ShipperRepository
        {
            get
            {
                if (this.shipperRepository == null)
                {
                    this.shipperRepository = new GenericRepository<Shipper>(context);
                }
                return shipperRepository;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public List<Shipment> GetShippment(int id)
        {
            var result = new List<Shipment>();
            using (var sqlConnection = new SqlConnection(context.GetConnectionString()))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("Sp_GetShippmentList_ById", sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@ShipperId", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataSet);
                if (dataSet != null && dataSet.Tables[0] != null)
                {
                    result.AddRange(dataSet.Tables[0].AsEnumerable().Select(row =>
                    new Shipment
                    {
                        ShipmentId = row.Field<int>("shipment_id"),
                        ShipmentDescription = row.Field<string>("shipment_description"),
                        ShipmentWeight = row.Field<decimal>("shipment_weight"),
                        CarrierId = row.Field<int>("carrier_id"),    
                        ShipperId = row.Field<int>("shipper_id"),    
                    }).ToList());
                }
                foreach (var shipment in result) {
                    if (dataSet != null && dataSet.Tables[1] != null)
                    {
                        shipment.Carrier = new Carrier();
                        shipment.Carrier = dataSet.Tables[1].Select($"shipment_id ={shipment.ShipmentId}").Select(row =>
                        new Carrier
                        {
                            CarrierId = row.Field<int>("carrier_id"),
                            CarrierName = row.Field<string>("carrier_name"),
                            CarrierMode = row.Field<string>("carrier_mode"),
                        }).ToList()[0];
                    }
                    if (dataSet != null && dataSet.Tables[2] != null)
                    {
                        shipment.Shipper = new Shipper();
                        shipment.Shipper = dataSet.Tables[2].Select($"shipment_id ={shipment.ShipmentId}").Select(row =>
                        new Shipper
                        {
                            ShipperId = row.Field<int>("shipper_id"),
                            ShipperName = row.Field<string>("shipper_name"),
                        }).ToList()[0];
                    }
                    if (dataSet != null && dataSet.Tables[3] != null)
                    {
                        shipment.ShipmentRate = new ShipmentRate();
                        shipment.ShipmentRate = dataSet.Tables[3].Select($"shipment_id ={shipment.ShipmentId}").Select(row =>
                        new ShipmentRate
                        {
                            ShipmentRateId = row.Field<int>("shipment_rate_id"),
                            ShipmentRateClass = row.Field<string>("shipment_rate_class"),
                            ShipmentRateDescription = row.Field<string>("shipment_rate_description"),
                        }).ToList()[0];
                    }
                }
                return result;
            }
        }


    }
}
