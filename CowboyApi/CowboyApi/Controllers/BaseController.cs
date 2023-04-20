using CowboyApi.Context;
using CowboyApi.Contracts;
using CowboyApi.Models;
using CowboyApi.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CowboyApi.Controllers
{
    public class BaseController<T> : ControllerBase, IBaseController<T> where T : BaseModel
    {
        public readonly CowContext _context;
        public BaseController(CowContext cowContext) 
        {
            _context = cowContext;
        }


        [HttpPost]
        [Route("[controller]/Add")]
        public async Task Add(T entity)
        {
            if(entity.Id == Guid.Empty) 
            {
                entity.Id = Guid.NewGuid();
            }

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("[controller]/Delete/{id}")]
        public async Task<bool> Remove(Guid id)
        {
            var entityToRemove = await _context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);

            if(entityToRemove != null)
            {
                _context.Set<T>().Remove(entityToRemove);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("[controller]/List")]
        public async Task<IEnumerable<T>> List()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

        [HttpGet]
        [Route("[controller]/Single/{id}")]
        public Task<T> Single(Guid id)
        {
            return _context.Set<T>().SingleAsync(s=>s.Id == id);
        }

        [HttpPost]
        [Route("[controller]/Update")]
        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return await Single(entity.Id);
        }
        [HttpPost]
        [Route("[controller]/UpdateRange")]
        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
            await _context.SaveChangesAsync();

           var result =  _context.Set<T>().UnionBy(entity.ToList(), x=>x.Id);
            return result.ToList();
        }

        [HttpPost]
        [Route("[controller]/AddRange")]
        public async Task AddRange(IEnumerable<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
