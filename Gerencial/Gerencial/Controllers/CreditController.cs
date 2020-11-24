using Gerencial.Models;
using Gerencial.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace Gerencial.Controllers
{
    public class CreditController : Controller
    {
        ApplicationDbContext _context;
        
        public CreditController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            List<Credit> credit = new List<Credit>();
            credit = _context.Credit.ToList().
                            Where(c => c.PaymentsDate.Year == year
                                        && c.PaymentsDate.Month == month).ToList();

            ViewBag.Total = credit.Sum(c => c.Value);

            List<Client> clientes = _context.Client.ToList();

            CreditViewModel viewModel = new CreditViewModel
            {
                DataPesquisa = DateTime.Now,
                Credit = credit,
                Client = clientes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(CreditViewModel CreditVM)
        {
            try
            {
                int year = CreditVM.DataPesquisa.Year;
                int month = CreditVM.DataPesquisa.Month;

                List<Credit> Credits = new List<Credit>();
                Credits = _context.Credit.ToList().
                                Where(c => c.PaymentsDate.Year == year
                                            && c.PaymentsDate.Month == month).ToList();

                float fTotal = Credits.Sum(c => c.Value);

                ViewBag.Total = fTotal;

                List<Client> clientes = _context.Client.ToList();

                CreditViewModel viewModel = new CreditViewModel
                {
                    DataPesquisa = CreditVM.DataPesquisa,
                    Credit = Credits,
                    Total = fTotal,
                    Client = clientes 
                };

                if (CreditVM.bImprimir)
                {
                    return View("Details", viewModel);
                }
                else
                    return View(viewModel);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Create(int id)
        {

            IEnumerable<Client> clientes = _context.Client.ToList();

            CreditVM creditVM = new CreditVM { 
                        Credit = new Credit { PaymentsDate = DateTime.Now, ClientId = id },
                        Client = clientes
            };

            return View("Create", creditVM);            
        }

        public ActionResult SelectClient()
        {
            List<Client> clientes = _context.Client.ToList();

            return View("Clients", clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreditVM CreditVM)
        {
            Credit credit = CreditVM.Credit;

            try
            {
                if ((!ModelState.IsValid))
                {
                    ViewBag.Acao = "Cadastrar Venda";

                    List<Client> clientes = _context.Client.ToList();

                    CreditVM = new CreditVM
                    {
                        Credit = new Credit { PaymentsDate = DateTime.Now },
                        Client = clientes
                    };

                    return View("Create", CreditVM);
                }

                if (credit.Id == 0)
                {
                    _context.Credit.Add(credit);
                }
                else
                {
                    var CreditInDb = _context.Credit.Single(s => s.Id == credit.Id);

                    CreditInDb.NameCredit = credit.NameCredit;
                    CreditInDb.Observation = credit.Observation;
                    CreditInDb.PaymentForm = credit.PaymentForm;
                    CreditInDb.PaymentsDate = credit.PaymentsDate;
                    CreditInDb.Value = credit.Value;
                    CreditInDb.ClientId = credit.ClientId;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Credit");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Credit");
            }
        }

        public ActionResult Edit(int id)
        {
            Credit credit = _context.Credit.Find(id);

            if (credit == null)
                return HttpNotFound();

            List<Client> clientes = _context.Client.ToList();

            CreditVM creditVM = new CreditVM
            {
                Credit = credit,
                Client = clientes
            };

            ViewBag.Acao = "Editar Venda";

            return View("Create", creditVM);
        }

        public ActionResult Delete(int id)
        {
            Credit credit = _context.Credit.Find(id);

            if (credit == null)
                return HttpNotFound();

            List<Client> clientes = _context.Client.ToList();

            CreditVM creditVM = new CreditVM
            {
                Credit = credit,
                Client = clientes
            };
                        
            return View(creditVM);
        }

        [HttpPost]
        public ActionResult Delete(Credit Credit)
        {
            try
            {
                if (Credit == null)
                    return HttpNotFound();

                Credit CreditDel = _context.Credit.Find(Credit.Id);

                if (CreditDel == null)
                    return HttpNotFound();

                _context.Credit.Remove(CreditDel);
                _context.SaveChanges();

                return RedirectToAction("Index", "Credit");
            }
            catch
            {
                return View();
            }
        }


    }
}