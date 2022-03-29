using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch;
using LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch;
using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoanProcessManagement.Application.Features.Product.Commands.CreateProductCommand;
using LoanProcessManagement.Application.Features.Product.Commands.UpdateProductCommand;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus;
using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency;

namespace LoanProcessManagement.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class MasterController : Controller
    {
        private IUserListService _userListService;
        private IRoleMasterService _roleMasterService;
        private readonly ICommonServices _commonService;
        private readonly IBranchService _branchService;
        private readonly IQueryTypeService _queryTypeService;
        private readonly ILpmCategoryServices _lpmCategoryServices;
        private ILostLeadReasonMasterService _lostLeadReasonMasterService;
        private IRejectLeadReasonMasterService _rejectLeadReasonMasterService;
        private readonly ISchemeService _schemeService;
        private readonly IProductService _productService;
        private readonly IInstitutionServices _institutionServices;
        private readonly ILeadStatusService _leadStatusService;
        private readonly IQualificationService _qualificationService;
        private readonly IStateService _stateService;
        private readonly IAgencyService _agencyService;



        //public MasterController(IUserListService userListService,IRoleMasterService roleMasterService, 
        //    ICommonServices commonService, IBranchService branchService, IQueryTypeService queryTypeService)



        public MasterController(IUserListService userListService,
            IRoleMasterService roleMasterService,
            ILostLeadReasonMasterService lostLeadReasonMasterService,
            IRejectLeadReasonMasterService rejectLeadReasonMasterService,
            ICommonServices commonService,
            IBranchService branchService,
            IQueryTypeService queryTypeService,
            ILpmCategoryServices lpmCategoryServices,
            ISchemeService schemeService,
            IProductService productService,
            IInstitutionServices InstitutionServices,
            ILeadStatusService leadStatusService,
            IQualificationService qualificationService,
            IStateService stateService,
            IAgencyService agencyService)
        {
            _userListService = userListService;
            _roleMasterService = roleMasterService;
            _commonService = commonService;
            _branchService = branchService;
            _queryTypeService = queryTypeService;
            _lpmCategoryServices = lpmCategoryServices;
            _schemeService = schemeService;
            _productService = productService;
            _institutionServices = InstitutionServices;
            _lostLeadReasonMasterService = lostLeadReasonMasterService;
            _rejectLeadReasonMasterService = rejectLeadReasonMasterService;
            _leadStatusService = leadStatusService;
            _qualificationService = qualificationService;
            _stateService = stateService;
            _agencyService = agencyService;
        }



        public async Task<IActionResult> Index()
        {

            return View();

        }
        [HttpGet]

        public async Task<IActionResult> GetRoleMaster()
        {
            var roleMaster = await _roleMasterService.RoleListProcess();
            var data = roleMaster.Data;
            ViewData["RoleMasterList"] = data;
            return View(data);
        }


        [HttpGet("/Master/AddRole")]
        public async Task<IActionResult> AddRole()
        {

            return View();
        }



        [HttpPost("/Master/AddRole")]
        public async Task<IActionResult> AddRole(CreateRoleMasterCommand createRoleMasterCommand)
        {

            var response = await _roleMasterService.CreateRoleMaster(createRoleMasterCommand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole([FromRoute] long id)
        {
            var Roledata = _roleMasterService.GetRoleMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRole([FromRoute] long id, UpdateRoleMasterVm roleMasterVm)
        {
            UpdateRoleMasterCommand rolemaster = new UpdateRoleMasterCommand()
            {
                Id = roleMasterVm.Id,
                RoleName = roleMasterVm.getRoleMasterByIdQueryVm.RoleName,
                LastModifiedDate = DateTime.Now
            };
            var response = await _roleMasterService.UpdateRoleMaster(rolemaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> DeleteRole([FromRoute] long Id)
        {
            var response = await _roleMasterService.DeleteRoleMaster(Id);
            return RedirectToAction("Index");
        }

  

        [HttpGet("/Master/GetAllBranches")]
        public async Task<IActionResult> GetAllBranch()
        {
            var branches = await _commonService.GetAllBranches();
            return View(branches);

        }

        [HttpGet("/Master/AddLostLeadReason")]
        public async Task<IActionResult> AddLostLeadReason()
        {
            return View();
        }
        [HttpPost("/Master/AddLostLeadReason")]
        public async Task<IActionResult> AddLostLeadReason(CreateLostLeadReasonMasterCommand createLostLeadReasonMasterCommand)
        {

            var response = await _lostLeadReasonMasterService.CreateLostLeadReasonMaster(createLostLeadReasonMasterCommand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateLostLeadReason([FromRoute] long id)
        {
            var Roledata = _lostLeadReasonMasterService.GetLostLeadReasonMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateLostLeadReason([FromRoute] long id, UpdateLostLeadReasonMasterVm updateLostLeadReasonMasterVm)
        {
            UpdateLostLeadReasonMasterCommand lostLeadReasonmaster = new UpdateLostLeadReasonMasterCommand()
            {
                LostLeadReasonId = id,
                LostLeadReason = updateLostLeadReasonMasterVm.getLostLeadReasonMasterByIdQueryVm.LostLeadReason,
                IsActive = updateLostLeadReasonMasterVm.getLostLeadReasonMasterByIdQueryVm.IsActive,
            };
            var response = await _lostLeadReasonMasterService.UpdateLostLeadReasonMaster(lostLeadReasonmaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteLostLeadReason([FromRoute] long Id)
        {
            var response = await _lostLeadReasonMasterService.DeleteLostLeadReasonMaster(Id);
            return RedirectToAction("Index");

        }
        

        public async Task<IActionResult> GetLostLeadReasonMaster()
        {
            var roleMaster = await _lostLeadReasonMasterService.GetByLostLeadReason();
            var data = roleMaster.Data;
            ViewData["GetByLostLeadReason"] = data;
            return View(data);
        }
        [HttpGet("/Master/AddRejectLeadReason")]
        public async Task<IActionResult> AddRejectLeadReason()
        {
            return View();
        }
        [HttpPost("/Master/AddRejectLeadReason")]
        public async Task<IActionResult> AddRejectLeadReason(CreateRejectedLeadReasonMasterCommand createRejectLeadReasonMasterCommand)
        {

            var response = await _rejectLeadReasonMasterService.CreateRejectLeadReasonMaster(createRejectLeadReasonMasterCommand);

            return RedirectToAction("Index");
        }

        [HttpGet("/Master/GetRejectLeadReasonMaster")]
        public async Task<IActionResult> GetRejectLeadReasonMaster()
        {
            var roleMaster = await _rejectLeadReasonMasterService.GetByRejectLeadReason();
            var data = roleMaster.Data;
            ViewData["GetByRejectLeadReason"] = data;
            return View(data);
        }

        public async Task<IActionResult> DeleteRejectLeadReason([FromRoute] long Id)
        {
            var response = await _rejectLeadReasonMasterService.DeleteRejectLeadReasonMaster(Id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateRejectLeadReason([FromRoute] long id)
        {
            var Roledata = _rejectLeadReasonMasterService.GetRejectLeadReasonMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;

            return View();
        }

        [HttpGet("/Master/AddBranch")]
        public async Task<IActionResult> AddBranch()
        {
            return View();
        }

        [HttpPost("/Master/AddBranch")]
        public async Task<IActionResult> AddBranch(CreateBranchCommand req)
        {
            if (ModelState.IsValid)
            {
                var response = await _branchService.AddBranch(req);
                //TempData["AddUserSuccess"] = response.Succeeded;
                //TempData["AddUserMessage"] = response.Data.Message;
                return Json(response);

            }
            return View();

        }

        [HttpGet("/Master/UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(long id)
        {
            var result = await _branchService.GetBranchById(id);
            var res = new UpdateBranchCommand() { 
                Id=result.Id,
                branchname=result.branchname,
                IsActive=result.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateBranch")]
        public async Task<IActionResult> UpdateBranch(UpdateBranchCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _branchService.UpdateBranch(req);
                return Json(result);
            }
            return View();
           
        }



        [HttpGet("/Master/DeleteBranch/{id}")]
        public async Task<IActionResult> DeleteBranch([FromRoute]long id)
        {
            var response = await _branchService.DeleteBranch(id);
            return Json(response);
        }

        [HttpGet("/Master/GetAllQueryType")]
        public async Task<IActionResult> GetAllQueryType()
        {
            var queries = await _queryTypeService.GetAllQueryTypes();
            return View(queries.Data);
        }

        
        [HttpGet("/Master/AddQueryType")]
        public async Task<IActionResult> AddQueryType()
        {
            return View();
        }

        [HttpPost("/Master/AddQueryType")]
        public async Task<IActionResult> AddQueryType(CreateQueryCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _queryTypeService.AddQueryType(req);
                return Json(result);
            }
            return View();
        }

        [HttpGet("/Master/DeleteQueryType/{id}")]
        public async Task<IActionResult> DeleteQueryType([FromRoute] long id)
        {
            var response = await _queryTypeService.DeleteQueryType(id);
            return Json(response);
        }

        [HttpGet("/Master/UpdateQuery/{id}")]
        public async Task<IActionResult> UpdateQuery(long id)
        {
            var result = await _queryTypeService.GetQueryTypeById(id);
            var res = new UpdateQueryCommand()
            {
                Id = result.Data.Id,
                QueryType = result.Data.QueryType,
                QueryName = result.Data.QueryName,
                IsActive = result.Data.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateQuery")]
        public async Task<IActionResult> UpdateQuery(UpdateQueryCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _queryTypeService.UpdateQuery(req);
                return Json(result);
            }
            return View();
         
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRejectLeadReason([FromRoute] long id, UpdateRejectLeadReasonMasterVm roleMasterVm)
        {
            UpdateRejectLeadReasonMasterCommand rolemaster = new UpdateRejectLeadReasonMasterCommand()
            {
                RejectLeadReasonId = id,
                RejectLeadReason = roleMasterVm.getRejectedLeadReasonMasterByIdDto.RejectLeadReason,
                IsActive = roleMasterVm.getRejectedLeadReasonMasterByIdDto.IsActive,
            };
            var response = await _rejectLeadReasonMasterService.UpdateRejectLeadReasonMaster(rolemaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }

        
        [HttpGet("/Master/GetAllLpmCategories")]
        public async Task<IActionResult> GetAllLpmCategories()
        {
            var categories = await _lpmCategoryServices.GetAllLpmCategories();
            return View(categories.Data);
        }
        
        [HttpGet("/Master/AddLpmCategory")]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost("/Master/AddLpmCategory")]
        public async Task<IActionResult> AddCategory(CreateLpmCategoryCommand req)
        {
            if (ModelState.IsValid)
            {
                var response = await _lpmCategoryServices.AddLpmCategory(req);           
                return Json(response);

            }
            return View();
        }

        [HttpGet("/Master/DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] long id)
        {
            var response = await _lpmCategoryServices.DeleteLpmCategory(id);
            return Json(response);
        }

        [HttpGet("/Master/UpdateLpmCategory/{id}")]
        public async Task<IActionResult> UpdateLpmCategory(long id)
        {
            var result = await _lpmCategoryServices.GetLpmCategoryById(id);
            var res = new UpdateLpmCategoryCommand()
            {
                Id = result.Data.Id,
                categoryName = result.Data.categoryName,
                IsActive = result.Data.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateLpmCategory")]
        public async Task<IActionResult> UpdateLpmCategory(UpdateLpmCategoryCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _lpmCategoryServices.UpdateLpmCategory(req);
                return Json(result);
            }
            return View();
        }

        [HttpGet("/Master/GetAllScheme")]
        public async Task<IActionResult> GetAllScheme()
        {
            var queries = await _schemeService.GetAllScheme();
            return View(queries.Data);
        }


        [HttpGet("/Master/AddScheme")]
        public async Task<IActionResult> AddScheme()
        {
            return View();
        }

        [HttpPost("/Master/AddScheme")]
        public async Task<IActionResult> AddScheme(CreateSchemeCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _schemeService.AddScheme(req);
                return Json(result);
            }
            return View();
        }

        [HttpGet("/Master/DeleteScheme/{id}")]
        public async Task<IActionResult> DeleteScheme([FromRoute] long id)
        {
            var response = await _schemeService.DeleteScheme(id);
            return Json(response);
        }

        [HttpGet("/Master/UpdateScheme/{id}")]
        public async Task<IActionResult> UpdateScheme(long id)
        {
            var result = await _schemeService.GetSchemeById(id);
            var res = new UpdateSchemeCommand()
            {
                Id = result.Data.Id,
                SchemeName = result.Data.SchemeName,
                IsActive = result.Data.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateScheme")]
        public async Task<IActionResult> UpdateScheme(UpdateSchemeCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _schemeService.UpdateScheme(req);
                return Json(result);
            }
            return View();
        }

        #region CRUD of Institution , Lead Status and Qualification By Dipti Pandhram- 22/03/20222

        /// <summary>
        /// CRUD Institution Master in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Master/GetAllInstitution")]
        public async Task<IActionResult> GetAllInstitution()
        {
            var insti = await _institutionServices.GetAllInstitutions();
            return View(insti.Data);

        }

        [HttpGet("/Master/AddInstitutionMaster")]
        public async Task<IActionResult> AddInstitutionMaster()
        {

            return View();
        }

        [HttpPost("/Master/AddInstitutionMaster")]
        public async Task<IActionResult> AddInstitutionMaster(CreateInstitutionMastersCommand req)
        {

            if (ModelState.IsValid)
            {
                var response = await _institutionServices.CreateInstitutionMastersCommand(req);

                return Json(response);

            }
            return View();
        }

        [HttpGet("/Master/DeleteInstitutionMaster/{id}")]
        public async Task<IActionResult> DeleteInstitutionMaster([FromRoute] long id)
        {
            var response = await _institutionServices.DeleteInstitutionMasters(id);
            return Json(response);
        }


        [HttpGet("/Master/UpdateInstitutionMaster/{id}")]
        public async Task<IActionResult> UpdateInstitutionMaster(long id)
        {
            var result = await _institutionServices.GetInstitutionMastersById(id);
            var res = new UpdateInstitutionMastersCommand()
            {
                Id = result.Data.Id,
                Institution_Name = result.Data.Institution_Name,
                Institution_Type = result.Data.Institution_Type,
                IsActive = result.Data.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateInstitutionMaster/")]
        public async Task<IActionResult> UpdateInstitutionMaster(UpdateInstitutionMastersCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _institutionServices.UpdateInstitutionMasters(req);
                return Json(result);
            }
            return View();

        }


        /// <summary>
        /// CRUD of Lead Status in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Master/GetAllLeadStatus")]
        public async Task<IActionResult> GetAllLeadStatus()
        {
            var insti = await _leadStatusService.GetAllLeadStatus();
            return View(insti.Data);

        }
        [HttpGet("/Master/AddLeadStatus")]

        public async Task<IActionResult> AddLeadStatus()
        {

            return View();
        }

        [HttpPost("/Master/AddLeadStatus")]
        public async Task<IActionResult> AddLeadSt(CreateLeadStatusCommand req)
        {

            if (ModelState.IsValid)
            {
                var response = await _leadStatusService.AddLeadSt(req);

                return Json(response);

            }
            return View();
        }


        [HttpGet("/Master/DeleteLeadStatus/{id}")]
        public async Task<IActionResult> DeleteLeadSt([FromRoute] long id)
        {
            var response = await _leadStatusService.DeleteLeadSt(id);
            return Json(response);
        }


        [HttpGet("/Master/UpdateLeadStatus/{id}")]
        public async Task<IActionResult> UpdateLeadStatus(long id)
        {
            var result = await _leadStatusService.GetLeadStatusById(id);
            var res = new UpdateLeadStatusCommand()
            {
                Id = result.Data.Id,
                SerialOrder = result.Data.SerialOrder,
                StatusDescription = result.Data.StatusDescription,
                IsActive = result.Data.IsActive,
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateLeadStatus/")]
        public async Task<IActionResult> UpdateLeadStatus(UpdateLeadStatusCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _leadStatusService.UpdateLeadStatus(req);
                return Json(result);
            }
            return View();

        }

        [HttpGet("/Master/Getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return View(products.Data);

        }

        [HttpGet("/Master/AddProduct")]
        public async Task<IActionResult> AddProduct()
        {
            var scheme = await _schemeService.GetAllScheme();
            ViewBag.schemes = new SelectList(scheme.Data, "Id", "SchemeName");
            return View();
        }

        [HttpPost("/Master/AddProduct")]
        public async Task<IActionResult> AddProduct(CreateProductCommand req)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.AddProduct(req);
                return Json(response);

            }
            return View();
        }
        [HttpGet("/Master/DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var response = await _productService.DeleteProduct(id);
            return Json(response);
        }

        [HttpGet("/Master/UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(long id)
        {
            var result = await _productService.GetProductById(id);
            var scheme = await _schemeService.GetAllScheme();
            ViewBag.schemes = new SelectList(scheme.Data, "Id", "SchemeName");
            var res = new UpdateProductCommand()
            {
                Id = result.Data.Id,
                ProductName = result.Data.ProductName,
                ProducDescription=result.Data.ProducDescription,
                ProductType=result.Data.ProductType,
                Schemes=result.Data.Schemes,
                IsActive = result.Data.IsActive
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProduct(req);
                return Json(result);
            }
            return View();

        }


        /// <summary>
        ///  CRUD of Qualification in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Master/GetAllQualification")]
        public async Task<IActionResult> GetAllQualification()
        {
            var qual = await _qualificationService.GetAllQualification();
            return View(qual.Data);

        }

        [HttpGet("/Master/AddQualification")]
        public async Task<IActionResult> AddQualification()
        {

            return View();
        }

        [HttpPost("/Master/AddQualification")]
        public async Task<IActionResult> AddQualification(CreateQualificationCommand req)
        {

            if (ModelState.IsValid)
            {
                var response = await _qualificationService.AddQualification(req);

                return Json(response);

            }
            return View();
        }


        [HttpGet("/Master/DeleteQualification/{id}")]
        public async Task<IActionResult> DeleteQualification([FromRoute] long id)
        {
            var response = await _qualificationService.DeleteQualification(id);
            return Json(response);
        }


        [HttpGet("/Master/UpdateQualification/{id}")]
        public async Task<IActionResult> UpdateQualification(long id)
        {
            var result = await _qualificationService.GetQualificationById(id);
            var res = new UpdateQualificationCommand()
            {
                Id = result.Data.Id,
                QualificationName = result.Data.QualificationName,
                IsActive = result.Data.IsActive,
            };

            return View(res);
        }


        [HttpPut("/Master/UpdateQualification")]
        public async Task<IActionResult> UpdateQualification(UpdateQualificationCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _qualificationService.UpdateQualification(req);
                return Json(result);
            }
            return View();

        }
        #endregion

        [HttpGet("/Master/GetAllState")]
        public async Task<IActionResult> GetAllState()
        {
            var stat = await _stateService.GetAllState();
            return View(stat.Data);

        }


        [HttpGet("/Master/AddState")]
        public async Task<IActionResult> AddState()
        {

            return View();
        }

        [HttpPost("/Master/AddState")]
        public async Task<IActionResult> AddState(CreateStateCommand req)
        {

            if (ModelState.IsValid)
            {
                var response = await _stateService.AddState(req);

                return Json(response);

            }
            return View();
        }


        [HttpGet("/Master/DeleteState/{id}")]
        public async Task<IActionResult> DeleteState([FromRoute] long id)
        {
            var response = await _stateService.DeleteState(id);
            return Json(response);
        }


        [HttpGet("/Master/UpdateState/{id}")]
        public async Task<IActionResult> UpdateState(long id)
        {
            var result = await _stateService.GetStateById(id);
            var res = new UpdateStateCommand()
            {
                Id = result.Data.Id,
                StateName =result.Data.StateName,
                IsActive = result.Data.IsActive,
            };

            return View(res);
        }


        [HttpPut("/Master/UpdateState")]
        public async Task<IActionResult> UpdateState(UpdateStateCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _stateService.UpdateState(req);
                return Json(result);
            }
            return View();

        }


        [HttpGet("/Master/GetAgencyList")]
        public async Task<IActionResult> GetAgencyList()
        {
            var stat = await _agencyService.GetAgencyList();
            return View(stat.Data);

        }


        [HttpGet("/Master/AddAgency")]

        public async Task<IActionResult> AddAgency()
        {

            return View();
        }

        [HttpPost("/Master/AddAgency")]
        public async Task<IActionResult> AddAgency(CreateAgencyCommand req)
        {

            if (ModelState.IsValid)
            {
                var response = await _agencyService.AddAgency(req);

                return Json(response);

            }
            return View();
        }


        [HttpGet("/Master/DeleteAgency/{id}")]
        public async Task<IActionResult> DeleteAgency([FromRoute] long id)
        {
            var response = await _agencyService.DeleteAgency(id);
            return Json(response);
        }


        [HttpGet("/Master/UpdateAgency/{id}")]
        public async Task<IActionResult> UpdateAgency(long id)
        {
            var result = await _agencyService.GetAgencyById(id);
            var res = new UpdateAgencyCommand()
            {
                Id = result.Data.Id,
                AgencyName = result.Data.AgencyName,
                Agency_type = result.Data.Agency_type,
                IsActive = result.Data.IsActive,
            };

            return View(res);
        }

        [HttpPut("/Master/UpdateAgency/")]
        public async Task<IActionResult> UpdateAgency(UpdateAgencyCommand req)
        {
            if (ModelState.IsValid)
            {
                var result = await _agencyService.UpdateAgency(req);
                return Json(result);
            }
            return View();

        }

    }
}
