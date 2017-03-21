﻿using NLayerDepotsApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.BLL.Interfaces
{
    public interface IService
    {
        IEnumerable<DrugUnitDTO> GetDrugUnits();
    }
}