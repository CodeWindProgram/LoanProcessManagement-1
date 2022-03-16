using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class DsaDashboardReportController : Controller
    {
        private readonly ICommonServices _commonService;
        private readonly IDsaDashboardReportService _dsaDashboardReportService;
        private readonly IBranchService _branchService;
        public DsaDashboardReportController(ICommonServices commonService, IDsaDashboardReportService dsaDashboardReportService, IBranchService branchService)
        {
            _commonService = commonService;
            _dsaDashboardReportService = dsaDashboardReportService;
            _branchService = branchService;
        }
        [Authorize(AuthenticationSchemes = "Cookies", Roles = "HO,Branch,DSA")]
        [HttpGet]
        public async Task<IActionResult> DsaDashboardReport()
        {
            ViewBag.RoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            List<DsaDashboardReportDto> result = new List<DsaDashboardReportDto>();
            ViewData["DsaDashboardReport"] = result;
            if(ViewBag.RoleId == 2)
            {
                var branches = await _commonService.GetAllBranches();
                ViewBag.branches = new SelectList(branches, "Id", "branchname");
            }
            else if(ViewBag.RoleId == 3 || ViewBag.RoleId == 4)
            {
                ViewBag.Id = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
                ViewBag.branchname = (User.Claims.First(c => c.Type == "Branch").Value);
            }
            return View();
        }
        [Authorize(AuthenticationSchemes = "Cookies", Roles = "HO,Branch,DSA")]
        [HttpPost]
        public async Task<IActionResult> DsaDashboardReport(DsaDashboardReportQuery dsaDashboardQuery)
        {           
            ViewBag.RoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            
            List<DsaDashboardReportDto> result = new List<DsaDashboardReportDto>();

            var dsaDashboardResponse = await _dsaDashboardReportService.DsaDashboardService(dsaDashboardQuery);

            if (ViewBag.RoleId == 2)
            {
                var branches = await _commonService.GetAllBranches();
                ViewBag.branches = new SelectList(branches, "Id", "branchname");
            }
            else if (ViewBag.RoleId == 3 || ViewBag.RoleId == 4)
            {
                ViewBag.Id = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
                ViewBag.branchname = (User.Claims.First(c => c.Type == "Branch").Value);            
            }
            if (dsaDashboardResponse != null)
                ViewData["DsaDashboardReport"] = dsaDashboardResponse.Data;
            else
                ViewData["DsaDashboardReport"] = result;
            return View();
        }
    }
}
