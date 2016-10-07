<?php
$servername = "mysql8.000webhost.com";
$server_username = "a6678073_user";
$server_password = "test123";
$dbName = "a6678073_wizard";
  $username = $_POST["usernamePost"];

  //Make Connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  //Check Connection
  if(!$conn){
    die("Connection to Server failed. ". mysqli_connect_error());
  }

  $sql = "SELECT * FROM users WHERE name = '".$username."'";
  $result = mysqli_query($conn, $sql);

  if(mysqli_num_rows($result) == 1){
    $row = mysqli_fetch_assoc($result);
    echo "'id':".$row['id']."|'class':".$row['class']."|'lvl':".$row['lvl']."|'max_xp':".$row['max_xp']."|'xp':".$row['xp']."|'m_xp':".$row['m_xp']."|'e_xp':".$row['e_xp']."|'lifes':".$row['lifes']."";
  }
?>
