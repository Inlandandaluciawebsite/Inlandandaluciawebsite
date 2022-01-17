<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControlFeaturedProperties.ascx.vb" Inherits="Controls_WebUserControlFeaturedProperties" %>

<script src="../js/featured/mg.js" type="text/javascript"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js" type="text/javascript"></script>
<script src="../js/featured/jquery.transform.min.js" type="text/javascript"></script>
<script src="../js/featured/jquery.bez.min.js" type="text/javascript"></script>
<script type="text/javascript">
    // bezier animations
    var bez = $.bez([.19, 1, .22, 1]);
    var bezcss = ".19,1,.22,1";
    /* Get css3 transition and transform prefixes */
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

<div class="featured1">
<div id="FeaturedFrames" runat="server"></div>
<div id="FeaturedProperties" runat="server"></div>
<div class="clearfloat"></div>
</div>
<div class="clearfloat"></div>
<script type="text/javascript">

    $('[id^="featured1a-item-"]').css("display", "block").css("position", "absolute").css("opacity", 0).css("z-index", "0");

    var featured1a = new Mg({
        reference: "featured1a",
        click: {
            activated: [0]
        }
    });
    featured1a.click.onEvent = function () {
        var path = $("#" + this.reference + "-item-" + this.deactivated);
        path.css("z-index", "0");
        path.stop().animate({ opacity: 0 }, { queue: true, duration: 1600, specialEasing: { opacity: bez} });
        var path = $("#" + this.reference + "-item-" + this.activated);
        path.css("z-index", "2").css("opacity", 0);
        path.stop().animate({ opacity: 1 }, { queue: true, duration: 1600, specialEasing: { opacity: bez} });
    }
    featured1a.init();

    //

    var featured1b = new Mg({
        reference: "featured1b",
        click: {
            activated: [0],
            interactive: true,
            linked: [featured1a.click],
            auto: 8000, autoSlow: 5000
        }
    });
    featured1b.click.onEvent = function () {
        $("#" + this.reference + "-item-" + this.deactivated).removeClass("active");
        $("#" + this.reference + "-item-" + this.activated).addClass("active");
    }
    featured1b.init();

</script>

