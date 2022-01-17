<script type="text/javascript">
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-46554073-1', 'auto');
  ga('send', 'pageview');

</script>
<!-- weather widget start -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js" type="text/javascript"></script>

<script src="../js/featured/mg.js" type="text/javascript"></script>
<script src="../js/featured/jquery.transform.min.js" type="text/javascript"></script>
<script src="../js/featured/jquery.bez.min.js" type="text/javascript"></script>
<script type="text/javascript">
var bez = $.bez([.19, 1, .22, 1]);
var bezcss = ".19,1,.22,1";
function mg_getProperty(arr0, arr1, arr2) {
var tmp = document.createElement("div");
for (var i = 0, len = arr0.length; i < len; i++) {
tmp.style[arr0[i]] = 800;
if (typeof tmp.style[arr0[i]] == 'string') {
return {
js: arr0[i],
css: arr1[i],
jsEnd: arr2[i]
};
}
}
return null;
}
function mg_getTransition() {
var arr0 = ["transition", "msTransition", "MozTransition", "WebkitTransition", "OTransition", "KhtmlTransition"];
var arr1 = ["transition", "-ms-transition", "-moz-transition", "-webkit-transition", "-o-transition", "-khtml-transition"];
var arr2 = ["transitionend", "MSTransitionEnd", "transitionend", "webkitTransitionEnd", "oTransitionEnd", "khtmlTransitionEnd"];
return mg_getProperty(arr0, arr1, arr2);
}
function mg_getTransform() {
var arr0 = ["transform", "msTransform", "MozTransform", "WebkitTransform", "OTransform", "KhtmlTransform"];
var arr1 = ["transform", "-ms-transform", "-moz-transform", "-webkit-transform", "-o-transform", "-khtml-transform"];
return mg_getProperty(arr0, arr1, []);
}
function mg_getPerspective() {
var arr0 = ["perspective", "msPerspective", "MozPerspective", "WebkitPerspective", "OPerspective", "KhtmlPerspective"];
var arr1 = ["perspective", "-ms-perspective", "-moz-perspective", "-webkit-perspective", "-o-perspective", "-khtml-perspective"];
return mg_getProperty(arr0, arr1, []);
}
var transition = mg_getTransition();
var transform = mg_getTransform();
var perspective = mg_getPerspective();
</script>
<!-- weather widget end -->