using LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IRoleMasterService
    {
        public Task<Response<IEnumerable<RoleMasterListVm>>> RoleListProcess();

        public Task<Response<CreateRoleMasterCommandDto>> CreateRoleMaster(CreateRoleMasterCommand createRoleMasterCommand);

        
        public GetRoleMasterByIdDto GetRoleMasterByIdAsync(long id);
        public Task<Response<UpdateRoleMasterDto>> UpdateRoleMaster(UpdateRoleMasterCommand lpmUserRoleMaster);
        public Task<Response<DeleteRoleMasterDto>> DeleteRoleMaster(long Id);

        public Task<Response<DeleteMenuMapByIdCommandDto>> DeleteMenuMapById(long Id);

        public Task<Response<IEnumerable<GetTheMenuMapsCommandDto>>> GetCheckList();

        public Task<Response<GetAllMenuMapsQueryVm>> CreateChecklist(GetAllMenuMapsQuery checklistCreate);
    }
}
