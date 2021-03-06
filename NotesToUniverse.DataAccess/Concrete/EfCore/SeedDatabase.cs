using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new DatabaseContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Notes.Count() == 0)
                {
                    context.Notes.AddRange(Notes);
                    context.AddRange(NoteCategories);
                }

                if (context.Comments.Count() == 0)
                {
                    context.Comments.AddRange(Comments);
                }

                if (context.Likes.Count() == 0)
                {
                    context.Likes.AddRange(Likes);
                }
            }

            context.SaveChanges();
        }


        private static Note[] Notes =
        {
            new Note(){Title = "Not 1 başlık", Text = "Not bir text kısmı açıklama", CreateOn = DateTime.Now,ModifiedOn = DateTime.Now,IsDraft = false},
            new Note(){Title = "Not 2 başlık", Text = "Not iki text kısmı açıklama", CreateOn = DateTime.Now,ModifiedOn = DateTime.Now,IsDraft = false},
            new Note(){Title = "Not 3 başlık", Text = "Not üç text kısmı açıklama", CreateOn = DateTime.Now,ModifiedOn = DateTime.Now,IsDraft = false}
        };

        private static Category[] Categories =
        {
            new Category() {Title = "24 saat", Description = "Son 24 Saatte en çok beğenilenler"},
            new Category() {Title = "7 Gün", Description = "Son 7 günde en çok beğenilenler"},
            new Category() {Title = "1 Ay", Description = "Son 1 Ay da en çok beğenilenler"},
            new Category() {Title = "Tüm Zamanlar", Description = "Tüm zamanların en çok beğenilenleri"},
            new Category() {Title = "En Çok Yorum alanlar", Description = "En çok yorum alanlar"}
        };

        private static NoteCategory[] NoteCategories =
        {
            new NoteCategory(){Note = Notes[0],Category = Categories[0]},
            new NoteCategory(){Note = Notes[1],Category = Categories[1]},
            new NoteCategory(){Note = Notes[2],Category = Categories[2]},
            new NoteCategory(){Note = Notes[2],Category = Categories[1]}

        };

        private static Comment[] Comments =
        {
            new Comment(){Text = "yorum 1", Note = Notes[0], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now},
            new Comment(){Text = "yorum 2", Note = Notes[2], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now},
            new Comment(){Text = "yorum 3", Note = Notes[1], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now},
            new Comment(){Text = "yorum 4", Note = Notes[0], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now},
            new Comment(){Text = "yorum 5", Note = Notes[2], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now},
            new Comment(){Text = "yorum 6", Note = Notes[2], CreateOn = DateTime.Now,ModifiedOn = DateTime.Now}
        };

        private static Liked[] Likes =
        {
            new Liked(){Note = Notes[0],LikedUser = "Emre"},
            new Liked(){Note = Notes[1],LikedUser = "Faruk"},
            new Liked(){Note = Notes[2],LikedUser = "Şeyma"},
            new Liked(){Note = Notes[2],LikedUser = "Berkay"},
            new Liked(){Note = Notes[0],LikedUser = "user"},
            new Liked(){Note = Notes[0],LikedUser = "user0"},
            new Liked(){Note = Notes[0],LikedUser = "user1"},
        };

    }
}
