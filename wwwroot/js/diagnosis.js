$(function () {
    $(".tablebtn").click(function () { 
        $(".uniquetbl").hide(); 
        $(this).siblings(".uniquetbl").show(); 
    });
});