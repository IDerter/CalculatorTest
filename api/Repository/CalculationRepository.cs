using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly ApplicationDBContext _context;

        public CalculationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Calculator>> GetAllAsync()
        {
             var calculations = _context.Calculations.ToListAsync();

             return calculations;
        }
    }
}