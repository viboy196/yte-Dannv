// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$('#btnDangNhap').click(function () {
//    $('#exampleModal').modal('show');
//})

//$('#btnLogIn').click(function () {
//    var account = new Object();
//    account.Phone = $('#lg_InputNumber').val();
//    account.Password = $('#lg_InputPassword1').val();
//    alert(JSON.stringify(account))
//    $.ajax({
//        type: "POST",
//        url: "Account/Login/",
//        data: JSON.stringify(account),
//        contentType: "application/json; charset=utf-8",
//        accepts: "text/plain",
//        success: function (response) {
//            if (response != null) {
//                $("#AccountStatus").html('<a>xin chào ' + response.nguoiDung.name + '</a>< button class= "btn btn-outline-primary" onclick="LogOut()"  > Đăng Xuất</button >');

//            } else {
//                alert("success Something went wrong");
//            }
//        },
//        failure: function (response) {
//            alert("failure " + response.responseText);
//        },
//        error: function (response) {
//            alert("error "+ response.responseText);
//        }
//    });
//})

//function LogOut() {
//    $.ajax({
//        type: "POST",
//        url: "Account/Logout",
//        async: true,
//        success: function (msg) {
//            alert('Đăng xuất thành công')
//            $("#AccountStatus").html('<button class="btn btn-outline-primary" data-bs-toggle="modal" data-bs-target="#loginModal">Đăng nhập</button>');
//        },
//        error: function (req, status, error) {
//            alert('faile');
//        }
//    });
//}

jQuery(document).ready(function ($) {
	var $form_modal = $('.cd-user-modal'),
		$form_login = $form_modal.find('#cd-login'),
		$form_signup = $form_modal.find('#cd-signup'),
		$form_forgot_password = $form_modal.find('#cd-reset-password'),
		$form_active_account = $form_modal.find('#cd-active-account'),
		$form_modal_tab = $('.cd-switcher'),
		$tab_login = $form_modal_tab.children('li').eq(0).children('a'),
		$tab_signup = $form_modal_tab.children('li').eq(1).children('a'),
		$forgot_password_link = $form_login.find('.cd-form-bottom-message a'),
		$back_to_login_link = $form_forgot_password.find('.cd-form-bottom-message a'),
		$btn_login =
			$main_nav = $('.main-nav');

	//open modal
	$main_nav.on('click', function (event) {

		if ($(event.target).is($main_nav)) {
			// on mobile open the submenu
			$(this).children('ul').toggleClass('is-visible');
		} else {
			// on mobile close submenu
			$main_nav.children('ul').removeClass('is-visible');
			//show modal layer
			$form_modal.addClass('is-visible');
			//show the selected form
			($(event.target).is('.cd-signup')) ? signup_selected() : login_selected();
		}

	});
	$('#btnLogin').on('click', function () {
		$form_modal.addClass('is-visible');
		login_selected();
	});

	//close modal
	$('.cd-user-modal').on('click', function (event) {
		if ($(event.target).is($form_modal) || $(event.target).is('.cd-close-form')) {
			$form_modal.removeClass('is-visible');
		}
	});
	//close modal when clicking the esc keyboard button
	$(document).keyup(function (event) {
		if (event.which == '27') {
			$form_modal.removeClass('is-visible');
		}
	});

	//switch from a tab to another
	$form_modal_tab.on('click', function (event) {
		event.preventDefault();
		($(event.target).is($tab_login)) ? login_selected() : signup_selected();
	});

	//hide or show password
	$('.hide-password').on('click', function () {
		var $this = $(this),
			$password_field = $this.prev('input');

		('password' == $password_field.attr('type')) ? $password_field.attr('type', 'text') : $password_field.attr('type', 'password');
		('Ẩn' == $this.text()) ? $this.text('Hiện') : $this.text('Ẩn');
		//focus and move cursor to the end of input field
		$password_field.putCursorAtEnd();
	});

	//show forgot-password form 
	$forgot_password_link.on('click', function (event) {
		event.preventDefault();
		forgot_password_selected();
	});

	//back to login from the forgot-password form
	$back_to_login_link.on('click', function (event) {
		event.preventDefault();
		login_selected();
	});

	function login_selected() {
		$form_login.addClass('is-selected');
		$form_signup.removeClass('is-selected');
		$form_forgot_password.removeClass('is-selected');
		$form_active_account.removeClass('is-selected');
		$tab_login.addClass('selected');
		$tab_signup.removeClass('selected');
	}

	function signup_selected() {
		$form_login.removeClass('is-selected');
		$form_signup.addClass('is-selected');
		$form_forgot_password.removeClass('is-selected');
		$form_active_account.removeClass('is-selected');
		$tab_login.removeClass('selected');
		$tab_signup.addClass('selected');
	}

	function forgot_password_selected() {
		$form_login.removeClass('is-selected');
		$form_signup.removeClass('is-selected');
		$form_forgot_password.addClass('is-selected');
	}

	function forgot_activate_selected() {
		$form_login.removeClass('is-selected');
		$form_signup.removeClass('is-selected');
		$form_active_account.addClass('is-selected');
	}

	////REMOVE THIS - it's just to show error messages 
	//$form_login.find('input[type="submit"]').on('click', function (event) {
	//	event.preventDefault();
	//	$form_login.find('input[type="email"]').toggleClass('has-error').next('span').toggleClass('is-visible');
	//});
	//$form_signup.find('input[type="submit"]').on('click', function (event) {
	//	event.preventDefault();
	//	$form_signup.find('input[type="email"]').toggleClass('has-error').next('span').toggleClass('is-visible');
	//});


	//IE9 placeholder fallback
	//credits http://www.hagenburger.net/BLOG/HTML5-Input-Placeholder-Fix-With-jQuery.html
	//if (!Modernizr.input.placeholder) {
	//	$('[placeholder]').focus(function () {
	//		var input = $(this);
	//		if (input.val() == input.attr('placeholder')) {
	//			input.val('');
	//		}
	//	}).blur(function () {
	//		var input = $(this);
	//		if (input.val() == '' || input.val() == input.attr('placeholder')) {
	//			input.val(input.attr('placeholder'));
	//		}
	//	}).blur();
	//	$('[placeholder]').parents('form').submit(function () {
	//		$(this).find('[placeholder]').each(function () {
	//			var input = $(this);
	//			if (input.val() == input.attr('placeholder')) {
	//				input.val('');
	//			}
	//		})
	//	});
	//}

	$('#form-login-submit').on('click', function () {

		const url = document.URL;
		const strsub = url.split('?');


		let check = true;
		$('#login_phone_Err').removeClass('is-visible');
		$('#login_pass_Err').removeClass('is-visible');

		let phone = $('#signin-phone').val();
		let pass = $('#signin-password').val();

		if (phone == null || phone == '') {
			$('#login_phone_Err').toggleClass('is-visible').text('Nhập số điện thoại');
			check = false;
		}
		if (pass == null || pass == '') {
			$('#login_pass_Err').toggleClass('is-visible').text('Nhập mật khẩu');
			check = false;
		}
		if (!check) return;
		let account = new Object();
		account.Phone = phone;
		account.Password = pass;
		$.ajax({
			url: '/Account/Login1' + '?' + strsub[1],
			type: 'POST',
			data: JSON.stringify(account),
			contentType: "application/json; charset=utf-8",
			accepts: "text/plain",
		}).done(function (kq) {
			const returnurl = kq.returnUrl;
			if (returnurl)
				location = returnurl;
			else {
				location.reload();
            }
		}).fail(function (e) {
			let err = e.responseJSON;
			let status = err.status;
			let login_phone_Err = status.phone_Err;
			let login_pass_Err = status.pass_Err;
			if (login_phone_Err != null) {
				$('#login_phone_Err').toggleClass('is-visible').text(login_phone_Err);
			}
			if (login_pass_Err != null) {
				$('#login_pass_Err').toggleClass('is-visible').text(login_pass_Err);
			}
		});
	}) // login
	$('#form-creat-submit').on('click', function () {
		let check = true;
		let signup_name_err = $('#signup_name_err').removeClass('is-visible');
		let signup_phone_err = $('#signup_phone_err').removeClass('is-visible');
		let signup_pass_err = $('#signup_pass_err').removeClass('is-visible');
		let signup_pass_redo_err = $('#signup_pass_redo_err').removeClass('is-visible');

		let name = $('#signup-name').val();
		let phone = $('#signup-phone').val();
		let pass = $('#signup-password').val();
		let pass_redo = $('#signup-password-redo').val();

		if (name == null || name == '') {
			signup_name_err.toggleClass('is-visible');
			check = false;
		}

		if (phone == null || phone == '') {
			signup_phone_err.toggleClass('is-visible');
			check = false;
		}
		if (pass == null || pass == '') {
			signup_pass_err.toggleClass('is-visible');
			check = false;
		}
		if (pass_redo == null || pass_redo == '') {
			signup_pass_redo_err.toggleClass('is-visible');
			check = false;
		}
		if (pass != pass_redo && !(pass_redo == null || pass_redo == '')) {
			signup_pass_redo_err.toggleClass('is-visible');
			signup_pass_redo_err.text('Mật khẩu không khớp')
			check = false;
		}

		if (check) {
			let account = new Object();
			account.Phone = phone;
			account.Password = pass;
			account.Name = name;
			$.ajax({
				url: '/Account/CreateAccount',
				type: 'POST',
				data: JSON.stringify(account),
				contentType: "application/json; charset=utf-8",
				accepts: "text/plain",
			}).done(function (kq) {
				forgot_activate_selected();
			}).fail(function (e) {
				let err = e.responseJSON;
				let status = err.status;
				let login_phone_Err = status.phone_Err;
				if (login_phone_Err != null) {
					signup_phone_err.toggleClass('is-visible').text(login_phone_Err);
				}

			});
		}

	}) // create
	$('#form-activate-account-submit').on('click', function () {
		let activate_code_err = $('#activate_code_err').removeClass('is-visible');
		let code = $('#input-activate-code').val();
		let phone = $('#signup-phone').val();
		let check = true;

		if (code === null || code === '') {
			activate_code_err.val('Nhập mã code');
			activate_code_err.toggleClass('is-visible');
			check = false;
		}
		if (check) {
			let account = new Object();
			account.Phone = phone;
			account.ActiveCode = code;
			$.ajax({
				url: '/Account/active',
				type: 'POST',
				data: JSON.stringify(account),
				contentType: "application/json; charset=utf-8",
				accepts: "text/plain",
			}).done(function (kq) {
				alert("Đăng ký tài khoản thành công");
				login_selected();
			}).fail(function (e) {
				let err = e.responseJSON;
				let status = err.status;
				let login_phone_Err = status.phone_Err;
				if (login_phone_Err != null) {
					signup_phone_err.toggleClass('is-visible').text(login_phone_Err);
				}

			});
		}

	}) // create

});


//credits https://css-tricks.com/snippets/jquery/move-cursor-to-end-of-textarea-or-input/
jQuery.fn.putCursorAtEnd = function () {
	return this.each(function () {
		// If this function exists...
		if (this.setSelectionRange) {
			// ... then use it (Doesn't work in IE)
			// Double the length because Opera is inconsistent about whether a carriage return is one character or two. Sigh.
			var len = $(this).val().length * 2;
			this.setSelectionRange(len, len);
		} else {
			// ... otherwise replace the contents with itself
			// (Doesn't work in Google Chrome)
			$(this).val($(this).val());
		}
	});
};