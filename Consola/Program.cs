using Persistence.Database.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            bool ejecucion = true;
            Tag tag;
            Post post;

            while (ejecucion)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Elegir una opción:");
                Console.WriteLine("1- Cargar nuevo TAG");
                Console.WriteLine("2- Cargar nuevo POST");
                Console.WriteLine("3- Listar todos los TAG");
                Console.WriteLine("4- Mostrar un TAG por ID");
                Console.WriteLine("5- Listar todos los POST");
                Console.WriteLine("6- Mostrar un POST por ID");
                Console.WriteLine("7- Buscar POSTS por su contenido");
                Console.WriteLine("8- Eliminar un POST por ID");
                Console.WriteLine("9- Modificar título de un POST por ID");
                Console.WriteLine("0- SALIR:");
                var opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        ejecucion = false;
                        break;
                    case 1:
                        Console.WriteLine("Escriba el nombre del nuevo TAG:");
                        var nombre = Console.ReadLine();
                        var tagNuevo = new Tag { Nombre = nombre };
                        TagService.Save(tagNuevo);
                        break;
                    case 2:
                        Console.WriteLine("Escriba el título del nuevo POST:");
                        var title = Console.ReadLine();
                        Console.WriteLine("Escriba el contenido del nuevo POST:");
                        var content = Console.ReadLine();
                        var postNuevo = new Post { Title = title, Content = content };
                        Console.WriteLine("Desea agregarle TAG? (1 = SI, 2 = NO): ");
                        var pregunta = Int32.Parse(Console.ReadLine());

                        List<Tag> tagList = new List<Tag>();
                        while (pregunta == 1)
                        {

                            Console.WriteLine("Ingrese id de tag: ");
                            tag = TagService.Get(Int32.Parse(Console.ReadLine()));

                            if (tag != null)
                            {
                                tagList.Add(tag);
                            }

                            Console.WriteLine("Desea agregar otro TAG? (1 = SI, 2 = NO): ");
                            pregunta = Int32.Parse(Console.ReadLine());
                        }

                        if (tagList.Count != 0)
                        {
                            postNuevo.Tags = tagList;
                        }

                        PostService.Save(postNuevo);
                        break;
                    case 3:
                        List<Tag> tags = TagService.GetAll();
                        foreach (var t in tags)
                        {
                            Console.WriteLine("- " + t.Nombre);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingresar el ID del TAG:");
                        var idTag = Int32.Parse(Console.ReadLine());
                        tag = TagService.Get(idTag);
                        if (tag != null)
                        {
                            Console.WriteLine("Nombre: " + tag.Nombre);
                            if (tag.Posts.Count != 0)
                            {
                                Console.WriteLine("Posts:");
                                foreach (var p in tag.Posts)
                                {
                                    Console.WriteLine("- " + p.Title);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No tiene post asociados.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encuentra dicho TAG");
                        }
                        break;
                    case 5:
                        List<Post> posts = PostService.GetAll();
                        foreach (var p in posts)
                        {
                            Console.WriteLine("- " + p.Title);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Ingresar el ID del POST:");
                        var idPost = Int32.Parse(Console.ReadLine());
                        post = PostService.Get(idPost);
                        if (post != null)
                        {
                            Console.WriteLine("Título: " + post.Title);
                            Console.WriteLine("Contenido:\n" + post.Content);

                            if (post.Tags.Count != 0)
                            {
                                Console.WriteLine("Tags:");
                                foreach (var t in post.Tags)
                                {
                                    Console.WriteLine("- " + t.Nombre);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No tiene tags asociados.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encuentra dicho POST");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Ingresa palabra o frase a buscar:");
                        var frase = Console.ReadLine();
                        List<Post> listaPost = PostService.BuscarPorContenido(frase);
                        if (listaPost.Count != 0)
                        {
                            Console.WriteLine("Posts encontrados:");
                            foreach (var p in listaPost)
                            {
                                Console.WriteLine("- " + p.Title);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron posts con ese contenido.");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Indique id post a eliminar:");
                        var b = PostService.Delete(Int32.Parse(Console.ReadLine()));
                        if (b)
                        {
                            Console.WriteLine("Se eliminó el post");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró post");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Ingrese ID de POST a modificar:");
                        var id = Int32.Parse(Console.ReadLine());
                        post = PostService.Get(id);
                        if (post != null)
                        {
                            Console.WriteLine("Título anterior: " + post.Title);

                            Console.WriteLine("Ingrese el nuevo Título:");
                            var nuevoTitutlo = Console.ReadLine();

                            if (nuevoTitutlo != "")
                            {
                                post.Title = nuevoTitutlo;
                            }
                            PostService.Save(post);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró POST");
                        }
                        break;
                    default:
                        Console.WriteLine("No existe esa opción.");
                        break;
                }

            }

        }


    }
}