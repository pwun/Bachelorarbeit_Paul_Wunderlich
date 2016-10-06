<?php
  $servername = "mysql8.000webhost.com";
  $server_username = "a6678073_user";
  $server_password = "test123";
  $dbName = "a6678073_wizard";

  $username = $_POST["usernamePost"];
  $password = $_POST["passwordPost"];

  //Make Connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  //Check Connection
  if(!$conn){
    die("Connection to Server failed. ". mysqli_connect_error());
  }

  $sql = "SELECT pw FROM users WHERE name = '".$username."'";
  $result = mysqli_query($conn, $sql);

  //Check Password
  if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
      if($row['pw'] == $password){
        echo "login success";
      }
      else {
        echo "password incorrect";
      }
    }
  }
  else {
    echo "user not found";
  }

?>
