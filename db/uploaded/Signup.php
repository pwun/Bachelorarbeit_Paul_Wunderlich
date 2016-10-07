<?php
$servername = "mysql8.000webhost.com";
$server_username = "a6678073_user";
$server_password = "test123";
$dbName = "a6678073_wizard";

  $username = $_POST["usernamePost"];
  $password = $_POST["passwordPost"];
  //$class = $_POST["classPost"];

  //Make connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  //Check connection
  if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
  }
  //  $sql = "INSERT INTO users (name, pw, class, lvl, xp, max_xp, m_xp, e_xp, lifes) VALUES ('".$username."','".$password."','".$class."',1,0,100,0,0,0)";

  $sql = "INSERT INTO users (name, pw, class, lvl, xp, max_xp, m_xp, e_xp, lifes) VALUES ('".$username."','".$password."',7,1,0,100,0,0,0)";
  $result = mysqli_query($conn, $sql);

  if(!$result) echo "registration failed.";
  else echo "registration success.";
?>
