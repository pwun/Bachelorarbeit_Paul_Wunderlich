<?php
$servername = "mysql8.000webhost.com";
$server_username = "a6678073_user";
$server_password = "test123";
$dbName = "a6678073_wizard";

  //$userId = $_POST["userIdPost"];

  //Make Connection
  $conn = new mysqli($servername, $server_username, $server_password, $dbName);
  //Check Connection
  if(!$conn){
    die("Connection to Server failed. ". mysqli_connect_error());
  }

  $sql = "SELECT id, question, answer FROM exercises";
  $result = mysqli_query($conn, $sql);

  if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
      echo "'id':".$row['id']."|'subject':".$row['subject']."|'difficulty':".$row['difficulty']."|'subject_category':"
      .$row['subject_category']."|'questiontype':".$row['questiontype']."|'answers':".$row['answers']."|'train':"
      .$row['train']."|'mini1':".$row['mini1']."|'mini2':".$row['mini2']."|'boss':".$row['boss']."|'question':"
      .$row['question']."|'answer':".$row['answer'].";";
    }
  }
?>
