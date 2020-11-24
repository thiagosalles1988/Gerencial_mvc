using Gerencial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace Gerencial.Controllers
{
    public class ClientController : Controller
    {
        ApplicationDbContext _context;
        // GET: Client
        public ClientController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searching)
        {
            List<Client> clientes;

            if (searching != null)
            {
                clientes = _context.Client.ToList().
                            Where(c => c.Name.ToLower().Contains(searching)).ToList(); 
            }
            else
                clientes = _context.Client.ToList();

            return View(clientes);
        }

        public ActionResult IndexSearch(string searching)
        {
            List<Client> clientes = _context.Client.ToList().
                            Where(c => c.Name == searching
                                        || c.Address == searching).ToList(); ;

            return View(clientes);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client client = _context.Client.Find(id);
            
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.Acao = "Novo Usuário";

            return View(new Client() { BirthDate = DateTime.Now });
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client Client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Acao = "Novo Usuário";

                    return View("Create", Client);
                }

                if (Client.Id == 0)
                {
                    _context.Client.Add(Client);

                    ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:", DateTime.Now.ToString());

                }
                else
                {
                    var clientInDb = _context.Client.Single(s => s.Id == Client.Id);

                    clientInDb.Mail = Client.Mail;
                    clientInDb.Name = Client.Name;
                    clientInDb.Address = Client.Address;
                    clientInDb.BirthDate = Client.BirthDate;
                    clientInDb.CellPhone = Client.CellPhone;
                    clientInDb.CPF = Client.CPF;
                    clientInDb.District = Client.District;
                    clientInDb.PhoneNumber = Client.PhoneNumber;
                    clientInDb.Profession = Client.Profession;
                    clientInDb.RG = Client.RG;
                    clientInDb.Sexo = Client.Sexo;
                    clientInDb.State = Client.State;
                    clientInDb.ZipCode = Client.ZipCode;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Client");
            }
            catch
            {
                return RedirectToAction("Index", "Client");
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client client = _context.Client.Find(id);

            if (client == null)
                return HttpNotFound();

            ViewBag.Acao = "Editar Usuário";

            return View("Create", client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            Client client = _context.Client.Find(id);
            if (client == null)
                return HttpNotFound();
            else
                return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(Client client)
        {
            try
            {
                if (client == null)
                    return HttpNotFound();

                Client clientDel = _context.Client.Find(client.Id);

                if (clientDel == null)
                    return HttpNotFound();

                _context.Client.Remove(clientDel);
                _context.SaveChanges();

                return RedirectToAction("Index", "Client");
            }
            catch
            {
                return View();
            }
        }
    }
}
