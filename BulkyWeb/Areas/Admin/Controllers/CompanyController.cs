using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }
        /* public IActionResult Create()
         {
             CompanyVM companyVM = new()
             {
                 CategoryList = (IEnumerable<System.Web.Mvc.SelectListItem>)_unitOfWork.Category.
                 GetAll().Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                 {
                     Text = u.Name,
                     Value = u.Id.ToString()
                 }).ToList(),
                 Company = new Company()
             };
         return View(companyVM);
         }*/

        public IActionResult Upsert(int? id)
        {
            // Fetch categories from your repository or database
            var categories = _unitOfWork.Category.GetAll();

            // Convert Category entities to SelectListItem
            var categoryList = categories.Select(c => new System.Web.Mvc.SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();

            // Create the view model
 
            if(id==null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                //Update
                Company CompanyObj = _unitOfWork.Company.Get(u=>u.Id==id);
                return View(CompanyObj);
            }

            
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
                if(CompanyObj.Id == 0) 
                {
                    _unitOfWork.Company.Add(CompanyObj);

                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);



                }
                _unitOfWork.Save();
                TempData["success"] = "Company Created SuccessFully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
            

        }
        /*public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? companyFromDb = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Company Deleted SuccessFully!";
            return RedirectToAction("Index");

        }*/

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data =  objCompanyList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id == id);

            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            return Json(new {success = true,message="Delete SuccessFull" });
        }
        #endregion
    }
}
