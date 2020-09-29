﻿using PRC_Project.Data.Models;
using PRC_Project.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRC_Project_Business.Services
{
  public  interface IOrderService
    {
        public Task<Orders> OrderProducts(IEnumerable<ProductModel> listProduct, string username);
    }
}
