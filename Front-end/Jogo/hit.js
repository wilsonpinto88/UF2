/*$(document).ready(function() {
        // executes when HTML-Document is loaded and DOM is ready
        alert("document is ready");
        });*/

function hit() {
  var value = document.getElementById("myHealth").clientWidth;
  var at = (document.getElementById("myHealth").style.width = value - 10);
  if (at >= 320) {
    document.getElementById("myHealth").style.backgroundColor = "green";
  } else if (at <= 320 && at >= 130) {
    document.getElementById("myHealth").style.backgroundColor = "yellow";
  } else {
    document.getElementById("myHealth").style.backgroundColor = "red";
  }
}
function hitPc() {
  var value = document.getElementById("pcHealth").clientWidth;
  var at = (document.getElementById("pcHealth").style.width = value - 10);
  if (at >= 320) {
    document.getElementById("pcHealth").style.backgroundColor = "green";
  } else if (at <= 320 && at >= 130) {
    document.getElementById("pcHealth").style.backgroundColor = "yellow";
  } else {
    document.getElementById("pcHealth").style.backgroundColor = "red";
  }
}

