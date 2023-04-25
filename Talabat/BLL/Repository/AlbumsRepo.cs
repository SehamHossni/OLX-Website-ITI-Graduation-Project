using BLL.Interface;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class AlbumsRepo
    {
        private readonly StoreContext _context;
        

        public AlbumsRepo(StoreContext context)
        {
            _context = context;
        }

        public async Task Add(productsandalbum Ent)
        {
            //var spec = new ProductsWithTypesAndCategoriesSpecification(Ent.ProductID);

            //Product product = await genericRepo.GetEntityWithSpec(spec);
            _context.albums.Add(Ent);
            _context.SaveChanges();

        }

        public async Task<List<string>> getalbums(int id)
        {
            //var spec = new ProductsWithTypesAndCategoriesSpecification(Ent.ProductID);

            //Product product = await genericRepo.GetEntityWithSpec(spec);
            List<string> images = _context.albums.Where(i=>i.prodid==id).Select(i => i.image).ToList();
            return images;

        }


    }
}
