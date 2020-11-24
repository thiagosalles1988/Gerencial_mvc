using CrystalDecisions.CrystalReports.Engine;
using Gerencial.Models;
using Gerencial.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace Gerencial.Controllers
{
    public class DebitController : Controller
    {
        ApplicationDbContext _context;
        
        public DebitController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Debit
        public ActionResult Index()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            List<Debit> debits = new List<Debit>();
            debits = _context.Debit.ToList().
                            Where(c => c.PaymentsDate.Year == year
                                        && c.PaymentsDate.Month == month).ToList();

            ViewBag.Total = debits.Sum(c => c.Value);

            DebitViewModel viewModel = new DebitViewModel
            {
                DataPesquisa = DateTime.Now,
                Debit = debits
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(DebitViewModel DebitVM)
        {
            try
            {
                int year = DebitVM.DataPesquisa.Year;
                int month = DebitVM.DataPesquisa.Month;

                List<Debit> debits = new List<Debit>();
                debits = _context.Debit.ToList().
                                Where(c => c.PaymentsDate.Year == year
                                            && c.PaymentsDate.Month == month).ToList();

                float fTotal = debits.Sum(c => c.Value);

                ViewBag.Total = fTotal;

                DebitViewModel viewModel = new DebitViewModel
                {
                    DataPesquisa = DebitVM.DataPesquisa,
                    Debit = debits,
                    Total = fTotal
                };

                if (DebitVM.bImprimir)
                {
                    #region // Crystal Reports
                    //ReportDocument rd = new ReportDocument();
                    //rd.Load(Path.Combine(Server.MapPath("~/Reports"), "crDebits.rpt"));

                    //rd.SetDataSource(debits);

                    //Response.Buffer = false;
                    //Response.ClearContent();
                    //Response.ClearHeaders();

                    //rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
                    //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

                    //Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    //stream.Seek(0, SeekOrigin.Begin);

                    //return File(stream, "application/pdf", "CustomerList.pdf"); 
                    #endregion

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

        public ActionResult Create()
        {
            ViewBag.Acao = "Cadastrar Despesa";

            return View(new Debit() { PaymentsDate = DateTime.Now }); ;
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Debit debit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Acao = "Cadastrar Despesa";

                    return View("Create", debit);
                }

                if (debit.Id == 0)
                {
                    _context.Debit.Add(debit);

                    ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:", DateTime.Now.ToString());

                }
                else
                {
                    var debitInDb = _context.Debit.Single(s => s.Id == debit.Id);

                    debitInDb.NameDebit = debit.NameDebit;
                    debitInDb.Observation = debit.Observation;
                    debitInDb.PaymentForm = debit.PaymentForm;
                    debitInDb.PaymentsDate = debit.PaymentsDate;
                    debitInDb.Value = debit.Value;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Debit");
            }
            catch
            {
                return RedirectToAction("Index", "Debit");
            }
        }

        public ActionResult Edit(int id)
        {
            Debit debit = _context.Debit.Find(id);

            if (debit == null)
                return HttpNotFound();

            ViewBag.Acao = "Editar Despesa";

            return View("Create", debit);
        }

        public ActionResult Delete(int id)
        {
            Debit debit = _context.Debit.Find(id);

            if (debit == null)
                return HttpNotFound();
            else
                return View(debit);
        }
                
        [HttpPost]
        public ActionResult Delete(Debit debit)
        {
            try
            {
                if (debit == null)
                    return HttpNotFound();

                Debit debitDel = _context.Debit.Find(debit.Id);

                if (debitDel == null)
                    return HttpNotFound();

                _context.Debit.Remove(debitDel);
                _context.SaveChanges();

                return RedirectToAction("Index", "Debit");
            }
            catch
            {
                return View();
            }
        }




    }
}