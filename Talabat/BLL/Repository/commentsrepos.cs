using BLL.Interface;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Specifications;

namespace BLL.Repository
{
    public class commentsrepos
    {
        private readonly StoreContext _context;
        private readonly IGenericRepo<Product> genericRepo;

        public commentsrepos(StoreContext context, IGenericRepo<Product> _genericRepo)
        {
            _context = context;
            this.genericRepo = _genericRepo;
        }


        public async Task Add(Comment Ent)
        {
            //var spec = new ProductsWithTypesAndCategoriesSpecification(Ent.ProductID);

            //Product product = await genericRepo.GetEntityWithSpec(spec);
            _context.Comments.Add(Ent);
            _context.SaveChanges();

        }

        public async Task Delete(int prodid)
        {
            List<Comment> comments = _context.Comments.Where(c=>c.ProductID==prodid).ToList();
            foreach (Comment comment in comments)
            {
                _context.Comments.Remove(comment);
            }

            
            await _context.SaveChangesAsync();
        }



    }
}
