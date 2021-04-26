const Baseurl="https://localhost:44327";
// checking is token valid
function LoginUser()
{
    // alert(form1.email.value);
    // alert(form1.password.value);

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    
    var raw = JSON.stringify({
      "Email":form1.Email.value,
      "Password": form1.Password.value
    });
    // "firstName": form1.fname.value,
    var requestOptions = {
      method: 'POST',
      headers: myHeaders,
      body: raw,
      redirect: 'follow'
    };
    
    fetch(Baseurl+"/api/Login", requestOptions)
      .then(response => response.json())
      .then(result => {
        if(result.token=='')
        {
            alert("Wrong Username And Password!")
        }  
        else
        {
            localStorage.setItem("player-management-token",result.token);
            // yeh code dusre page pe redirect krega
            location.replace("./Home.html")

        }
        })
      .catch(error => alert("Some Error Occured!"));
}
function LogOut()
{
    localStorage.removeItem("player-management-token");
    location.replace("./Login.html");
}
function CheckLogin()
{
  //
    if(localStorage.getItem("player-management-token")==null)
    {
        location.replace("./Login.html");

    }
}
function FetchData()
{
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer "+localStorage.getItem("player-management-token"));
    var requestOptions = {
        headers: myHeaders,
        method: 'GET',
        redirect: 'follow'
      };
      
      fetch(Baseurl+"/api/Player", requestOptions)
        .then(response => response.json())
        .then(result => {
          var StrGet="";
          
          result.forEach((user)=>{
            // console.log(user.address)
            StrGet += `<tr>
                 <td>${user.name} </td>
                 <td>${user.email}</td>
                 <td>${user.role} </td>
                 <td>${user.age}</td> 
                 <td>${user.nationality}</td> 
                 <td>${user.pteam}</td>
                 <td>${user.price}</td>
                 <td>
                 <button type="button" onclick="SelectUserForEdit('${user.email}')">Edit</button>
                 </td>
                 <td>
                 <button type="button" onclick="DeleteUser('${user.email}')">Delete</button>
                 </td>
                 </tr>`;
            // create list and bind
            // similarly do for rest functions
             document.getElementById("player-table-body").innerHTML=StrGet;
          });

        })
        .catch(error => console.log('error', error));

}
function HomeInit()
{
    // CheckLogin();
    FetchData();
}
function DeleteUser(Email)
{
  var IsDelete=confirm("Are You Sure That You Want To Delete ?");
  if(IsDelete==true)
  {
    var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer "+localStorage.getItem("player-management-token"));

var requestOptions = {
  method: 'DELETE',
  headers: myHeaders,
  redirect: 'follow'
};

fetch(Baseurl+"/api/Player/"+Email, requestOptions)
  .then(response => response.text())
  .then(result => {alert("Successfully Deleted User.")
  FetchData();
}
  )
  .catch(error => console.log('error', error));
  }
  else
  {
    return;
  }


}
function CreateUser()
{

     if(form1.Email.value=='')
     {
       alert("Please Enter An Email!");
       return;
     }

    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer "+localStorage.getItem("player-management-token"));
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
    "Name": form1.Name.value,
    "Email": form1.Email.value,
    // "gender": 1,
     "Role": form1.Role.value,
    "Price": form1.Price.value,
    "Nationality":form1.Nationality.value ,
    "Pteam": form1.Pteam.value,
    "Age": form1.Age.value,
    "Password":form1.Password.value,
    });

    var requestOptions = {
    method: 'POST',
    headers: myHeaders,
    body: raw,
    redirect: 'follow'
    };

    fetch(Baseurl+"/api/Player", requestOptions)//passing data from form to server side
    .then(response => response.json())
    .then(result => {
      console.log(result);
      if(result.email=='')
      {
       alert("Some Error Occured!")
      }
      else
      {
        alert("Inserted Successfully");
        FetchData();
      }
        

    })
    .catch(error => 
        console.log(error)
        );
}
function SelectUserForEdit(Email)
{
//code for feting info by using id
var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer "+localStorage.getItem("player-management-token"));

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch(Baseurl+"/api/Player/"+Email, requestOptions)
  .then(response => response.json())
  .then(result => {console.log(result)
    form1.Name.value=result.name;
    form1.Email.value=result.email;
    form1.Role.value=result.role;
    form1.Price.value=result.price;
    form1.Nationality.value=result.nationality;
    form1.Pteam.value=result.pteam;
    form1.Age.value=result.age;
    form1.Password.value=result.password;
  })
  .catch(error => console.log('error', error));

}

function Update()
{
  var Email=form1.Email.value;
  if(Email=='')
  {
    alert("Please Select A Record To Update!");
    return;
  }

  var myHeaders = new Headers();
  myHeaders.append("Authorization", "Bearer "+localStorage.getItem("player-management-token"));
  myHeaders.append("Content-Type", "application/json");
  
  // var raw = "{\r\n        \"firstName\": \"Ishansha\",\r\n        \"lastName\": \"Sharma\",\r\n        \"gender\": 1,\r\n        \"age\": 26,\r\n        \"city\": \"chandigarh\",\r\n        \"skills\": \"DSA , .NET Framework , React\",\r\n        \"email\": \"ishan98.es@gmail.com\",\r\n        \"password\": \"Ishan123\",\r\n        \r\n    }";
  var raw = JSON.stringify({
    "Name": form1.Name.value,
    // "Email": form1.Email.value,
    // "gender": 1,
    "Role": form1.Role.value,
    "Price": form1.Price.value,
    "Nationality":form1.Nationality.value ,
    // "email": form1.email.value,
    "Pteam": form1.Pteam.value,
    "age": form1.Age.value,
    "Password": form1.Password.value,
    });
  
  var requestOptions = {
    method: 'PUT',
    headers: myHeaders,
    body: raw,
    redirect: 'follow'
  };
  // Baseurl+"/api/player/"+email
  fetch(Baseurl+"/api/Player/"+Email, requestOptions)
    .then(response => response.json())
    .then(result => {
      console.log(result);
      if(result.email==null)
      {
        alert("Email Id Not Found!")
      }
      else
      {
        alert("Edited Successfully!");
        FetchData();
      }
      // console.log(result);
     
  })
    .catch(error => alert("An Error Occured!"));
}