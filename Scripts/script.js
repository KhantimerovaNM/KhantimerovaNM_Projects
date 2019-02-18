$(function(){

$("#textarea-quastions").hide();

	$( ".close" ).click(function() {
	 	$("fieldset").hide( "slow" );
	});

 	$(".value-textarea").click(function() {
		$("#textarea-quastions").show();
    	$( "#text-placeholder" ).hide();
 	});

 	$(".value-placeholder").click(function() {
		$("#textarea-quastions").hide();
    	$( "#text-placeholder" ).show();
 	});

	$("a").click(function() {
  		$( "fieldset" ).show( "slow" );
	});
    
    $("#buttonSave").click(function() {
       alert("Success");
    });
    

});	      

     