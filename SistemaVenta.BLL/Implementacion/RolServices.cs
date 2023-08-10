﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;


namespace SistemaVenta.BLL.Implementacion
{
    public class RolServices : IRolService
    {
        private readonly IGenericRepository<Rol> _repositorio;

        public RolServices(IGenericRepository<Rol> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Rol>> Lista()
        {
            
            IQueryable<Rol> query = await _repositorio.Consultar();
            return query.ToList();

        }
    }
}
