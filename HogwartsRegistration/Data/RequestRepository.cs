using HogwartsRegistration.Entities;
using HogwartsRegistration.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsRegistration.Data
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataBaseContext _context;

        public RequestRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long hogwartsId)
        {
            var requestToDelete = await  _context.Requests.FirstOrDefaultAsync(x => x.HogwartsId == hogwartsId);
            if (requestToDelete == null)
                throw new Exception("the inscription request you want to delete doesn't exist.");

             _context.Requests.Remove(requestToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InscriptionRequest>> GetInscriptionsAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task InsertAsync(InscriptionRequest request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InscriptionRequest updatedRequest)
        {
            var requestToUpdate = await _context.Requests.FirstOrDefaultAsync(r => r.HogwartsId == updatedRequest.HogwartsId);

             if(requestToUpdate == null)
                throw new Exception("the inscription request you want to update doesn't exist.");

            requestToUpdate.FirstName = updatedRequest.FirstName;
            requestToUpdate.LastName = updatedRequest.LastName;
            requestToUpdate.Age = updatedRequest.Age;
            requestToUpdate.Houses = updatedRequest.Houses;

            _context.Requests.Update(requestToUpdate);

            await _context.SaveChangesAsync();
        }
    }
}
