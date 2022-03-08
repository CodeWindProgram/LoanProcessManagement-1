var masterData = 0;
var len = 0;
$(document).ready(function () {
    $('#selectVideo').click(function () {
        if ($('#selectVideo').val() == 1) {
            $("#div_dynamicTables").load("../Master/GetRoleMaster");
            //$.ajax({
            //    type: 'GET',
            //    url: "/RoleMaster",
            //    async: false,
            //    contentType: 'application/json',
            //    success: function (data) {

            //        $('#showTable').empty();
            //        $('#div').empty();

            //        masterData = data[Object.keys(data)[3]];
            //        len = data[Object.keys(data)[3]].length;
            //        console.log(masterData);

            //        $('#div').append
            //            (`
            //                <button class="btn-default-submit float-left ml-1" id="act1" onclick="location.href='http://localhost:14018/Master/AddRole'">Add New Role</button>                        
            //            `)
            //        for (i = 0; i < len; i++) {

            //            $('#showTable').append
            //                (`

            //                     <tr>
            //                    <td>${masterData[i].id}</td>
            //                     <td>${masterData[i].roleName}</td>
            //                     <td>${masterData[i].isActive}</td>
            //                     <td>${masterData[i].lastModifiedDate}</td>
            //                     <td>${masterData[i].createdDate}</td>
            //                      <td><button id="updateBtn" class="btn btn-primary btn-md"
            //                          onclick="location.href='http://localhost:14018/Master/UpdateRole/'+'${masterData[i].id}'">Update</button>
            //                          </td>
            //                        <td><a href="DeleteRole", "Master", new { Id = ${masterData[i].id}}" onclick="return confirm('Are you sure you want to Delete?')" class="btn btn-danger">Delete</a></td>
            //                    </tr>

            //            `);
            //        }
            //    },

            //    error: function (error) {
            //        ajaxErrorOccured();
            //    }
            //});
        }
        
    });
    
});
