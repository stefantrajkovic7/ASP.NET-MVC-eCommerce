using eCommerce.DAL.Data;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class ProductRepository
    {
        internal DataContext context;

        public PublicRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual Product GetById(object id)
        {
            return context.Products.Find(id);
        }

        public virtual IQueryable<Product> GetAll()
        {
            return context.Products;
        }

        public virtual void Insert(Product entity)
        {
            context.Products.Add(entity);
        }

        public virtual void Update(Product entity)
        {
            context.Products.Attach(entity);
            context.Entry(entity).State == EntityState.Modified;
        }

        public virtual void Delete(Product entity)
        {
            if (context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                context.Products.Attach(entity);
            
        }
    }
}
