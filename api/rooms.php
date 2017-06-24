<?php
include 'connect.php';
$select = 'SELECT * FROM `rooms` WHERE `status`=0';        
$query = mysqli_query($db_server,$select);
$row = mysqli_fetch_assoc($query);
if ($row['id']) {
    echo '[';
    $f = false;
    do {
        if ($f) echo ',';
        $f = true;
        $jsonResult = json_encode($row);
        echo $jsonResult;
        
    } while ($row = mysqli_fetch_assoc($query));
    echo ']';   
}
?>