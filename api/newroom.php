<?php
include 'connect.php';
$requestBody = file_get_contents('php://input');
$request = json_decode($requestBody, true);
//echo $request['Name'];
if ($request !=0){
    
    $name = $request['Name'];
    //echo $name;
    $select = 'SELECT * FROM `rooms` WHERE `name`="'.$name.'"';        
    $query = mysqli_query($db_server,$select);
    $row = mysqli_fetch_assoc($query);
    

    if ($row['name']) {
        echo '{"Status":"Error","Error": "Ошибка! Такая комната уже существует"}';
    } else{
    $q="INSERT INTO `rooms` (name, status) VALUES('$name', 0);"; 
    mysqli_query($db_server,$q);
    echo '{"Status":"OK","Error":"No"}';
    }
}
?>