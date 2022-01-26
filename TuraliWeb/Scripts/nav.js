// Hide SubMenus.
$(".subMenu").hide();

// Shows SubMenu when it's parent is hovered.
$(".subMenu").parent("li").hover(function () {
    $(this).find(">.subMenu").not(':animated').slideDown(300);
    $(this).toggleClass("active ");
});

// Hides SubMenu when mouse leaves the zone.
$(".subMenu").parent("li").mouseleave(function () {
    $(this).find(">.subMenu").slideUp(150);
});

// Prevents scroll to top when clicking on <a href="#"> 
$("a[href=\"#\"]").click(function () {
    return false;
});