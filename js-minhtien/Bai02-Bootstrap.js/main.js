$(document).ready( function ()
{
 $('.header').height($(window).height());
 /*scroll effect*/
  $(".navbar a").on('click', function (event) {
    var position = $("#" + $(this).data('value')).offset().top;
    $("html, body").animate({ scrollTop: position }, 1000);
 })
})