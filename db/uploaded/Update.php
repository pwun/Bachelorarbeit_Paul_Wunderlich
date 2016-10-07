<?php
$servername = "mysql8.000webhost.com";
$server_username = "a6678073_user";
$server_password = "test123";
$dbName = "a6678073_wizard";

  $id = $_POST["idPost"];
  $lvl = $_POST["lvlPost"];
  $xp = $_POST["xpPost"];
  $max_xp = $_POST["max_xpPost"];
  $m_xp = $_POST["m_xpPost"];
  $e_xp = $_POST["e_xpPost"];
  $lifes = $_POST["lifesPost"];

  //Make connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  //Check connection
  if(!$conn){
    die("Connection Failed. ". mysqli_connect_error());
  }
  //  $sql = "INSERT INTO users (name, pw, class, lvl, xp, max_xp, m_xp, e_xp, lifes) VALUES ('".$username."','".$password."','".$class."',1,0,100,0,0,0)";

  $sql = "UPDATE users SET lvl=".$lvl.", xp=".$xp.", max_xp=".$max_xp.", m_xp=".$m_xp.", e_xp=".$e_xp.", lifes=".$lifes." WHERE id=".$id."";
  $result = mysqli_query($conn, $sql);

  if(!$result) echo "update failed.";
  else echo "update success.";
?>
