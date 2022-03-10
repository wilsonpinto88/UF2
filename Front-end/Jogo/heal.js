function heal() {
  var value = document.getElementById("myHealth").clientWidth;
  var at = (document.getElementById("myHealth").style.width);
  if (value >= 400){
    var at = (document.getElementById("myHealth").style.width = 500);
  }else{
    var at = (document.getElementById("myHealth").style.width = value + 100);
  }
  if (at >= 320) {
    document.getElementById("myHealth").style.backgroundColor = "green";
  } else if (at <= 320 && at >= 130) {
    document.getElementById("myHealth").style.backgroundColor = "yellow";
  } else {
    document.getElementById("myHealth").style.backgroundColor = "red";
  }
}
function healPc() {
  var valuePc = document.getElementById("pcHealth").clientWidth;
  var atPc = (document.getElementById("pcHealth").style.width);
  if (valuePc >= 400){
    var atPc = (document.getElementById("pcHealth").style.width = 500);
  }else{
    var atPc = (document.getElementById("pcHealth").style.width = valuePc + 100);
  }
  if (atPc >= 320) {
    document.getElementById("pcHealth").style.backgroundColor = "green";
  } else if (atPc <= 320 && atPc >= 130) {
    document.getElementById("pcHealth").style.backgroundColor = "yellow";
  } else {
    document.getElementById("pcHealth").style.backgroundColor = "red";
  }
}
