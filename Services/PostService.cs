using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Services
{
    public class PostService
    {
        public static Post Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Post post = ctx.Post.Where(p => p.Id == Id)
                    .Include(t => t.Tags).FirstOrDefault();
                return post;
            }
        }

        public static List<Post> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Post> posts = ctx.Post.ToList();

                return posts;
            }
        }

        public static void Save(Post post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if(post.Id != 0)
                    {
                        ctx.Entry(post).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Post.Add(post);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static List<Post> BuscarPorContenido(string contenido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Post> ListaPosts = ctx.Post.Where(p => p.Content.Contains(contenido)).ToList();

                return ListaPosts;
            }
        }

        public static bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Post resultado = Get(Id);

                if (resultado != null)
                {
                    ctx.Post.Remove(resultado);

                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        
    }
}
