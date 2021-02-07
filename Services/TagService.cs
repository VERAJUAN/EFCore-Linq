using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class TagService
    {
        public static void Save(Tag tag)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (tag.Id != 0)
                    {
                        ctx.Entry(tag).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Tag.Add(tag);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static Tag Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Tag tag = ctx.Tag.Where(t => t.Id == Id)
                    .Include(t => t.Posts).FirstOrDefault();
                return tag;
            }
        }

        public static List<Tag> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Tag> tags = ctx.Tag.ToList();

                return tags;
            }
        }
    }
}
