// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($) {

	"use strict";

	$('.label.ui.dropdown')
		.dropdown();

	$('.no.label.ui.dropdown')
		.dropdown({
			useLabels: false
		});

	$('.ui.button').on('click', function () {
		$('.ui.dropdown')
			.dropdown('restore defaults')
	})


})(jQuery);