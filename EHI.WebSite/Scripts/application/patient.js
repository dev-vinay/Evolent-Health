var appUrl = 'https://localhost:60137';
var apiUrl = '/api/PatientApi/';

function getPatientDetails() {
    $("#divAddPatient").hide();
    $.ajax({
        type: 'GET',
        url: '../api/PatientApi',
        dataType: 'JSON',
        success: function (data) {
            $("#tblPatient>tbody").empty();
            $.each(data, function (index, patient) {
                var activeStatus = patient.IsActive ? "Active" : "Inactive";
                var disableStatus = patient.IsActive ? "" : "disabled";
                var row = '<tr><td>' + patient.FirstName + ' ' + patient.LastName + '</td><td>' + patient.PhoneNumber + '</td><td>' + patient.EmailAddress + '</td><td>' + activeStatus + '</td><td><button type="button" name="Edit" id="' + patient.PatientID + '" class="btn btn-link" data-toggle="modal" data-targe="#myModal" onclick="editPatient(' + patient.PatientID + ')">Edit</button>|<button type="button" name="Details" id="' + patient.PatientID + '" class="btn btn-link" data-toggle="modal" data-targe="#myModal" onclick="detailsPatient(' + patient.PatientID + ')">Details</button>|<button type="button" name="Delete" id="' + patient.PatientID + '" class="btn btn-link" onclick="deletePatient(' + patient.PatientID + ')"' + disableStatus+' >Delete</button></td>';
                $("#tblPatient>tbody").append(row);
            });
            
            $('.btn .btn-link').attr("data - toggle", "modal");
            $('.btn .btn-link').attr("data - target", "#myModal");

        }
    });
}

function deletePatient(id) {
    var status = confirm("Are you sure you want to delete this patient detail?");
    if (status) {
        $.ajax({
            type: 'DELETE',
            url: '../api/PatientApi/' + id,
            dataType: 'JSON',
            success: function (data) {
                alert("Patient successfully deleted.");
                getPatientDetails();
            }
        });
    }
}

function showPage() {
    $("#postform").find('input').val('');
    $("#divAddPatient").show();
}

function cancel() {
    $("#postform").find('input').val('');
    $("#myModal").hide();
    $("#divPatientDetails").hide();
    $("#divAddPatient").hide();
}

function addPatient() {
    var apiUrl = '../api/PatientApi/';
    var patientId = $("#PatientID").val().trim();
    if (patientId) {
        apiUrl = '../api/PatientApi/' + patientId;
    }
    var newContact = {
        PatientID: $("#PatientID").val().trim(),
        FirstName: $("#FirstName").val().trim(),
        LastName: $("#LastName").val().trim(),
        PhoneNumber: $("#PhoneNumber").val().trim(),
        EmailAddress: $("#EmailAddress").val().trim(),
        IsActive: true
    }
    $.ajax({
        type: 'POST',
        url: apiUrl,
        data: newContact,
        dataType: 'JSON',
        success: function (data) {
            alert("Saved Successfully");
            $("#btnCancel").click();
            getPatientDetails();
        }
    });
}

function detailsPatient(id) {
    $.ajax({
        type: 'GET',
        url: '../api/PatientApi/' + id,
        dataType: 'JSON',
        success: function (data) {
            var activeStatus = data.IsActive ? "Active" : "Inactive";

            //$("#PatientName").text(data.FirstName + ' ' + data.LastName);
            //$("#PhoneNumber").text(data.PhoneNumber);
            //$("#EmailAddress").text(data.EmailAddress);
            //$("#activeStatus").text(activeStatus);
            //$("#modalTitle").text("Patient Detail");


            $("#divPatientDetails").html('<div><h4>' + data.FirstName + ' ' + data.LastName + '</h4><hr><dl class="dl-horizontal"><dt> Phone Number :</dt><dd>' + data.PhoneNumber + '</dd><dt>Email Address :</dt><dd>' + data.EmailAddress + '</dd><dt>Status :</dt><dd>' + activeStatus + '</dd></dl></div><div class="modal-footer"><button type="button" id="btnCancel" class="btn btn-default" data-dismiss="modal" onclick="cancel();">Cancel</button></div>');            
            $("#divPatientDetails").show();

        }
    });
}

function editPatient(id) {
    $.ajax({
        type: 'GET',
        url: '../api/PatientApi/' + id,
        dataType: 'JSON',
        success: function (data) {
            $("#PatientID").val(data.PatientID);
            $("#FirstName").val(data.FirstName);
            $("#LastName").val(data.LastName);
            $("#PhoneNumber").val(data.PhoneNumber);
            $("#EmailAddress").val(data.EmailAddress);
            $("#IsActive").val(data.IsActive);
            $("#modalTitle").text("Update Patient");
            $("#divAddPatient").show();
        }
    });
}