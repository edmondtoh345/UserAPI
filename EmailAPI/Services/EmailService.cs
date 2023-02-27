using MailKit.Net.Smtp;
using MimeKit;

namespace EmailAPI.Services
{
	public class EmailService : IEmailService
	{
		public void BlockedEmail(string email)
		{
			var blockedemail = new MimeMessage();
			blockedemail.From.Add(MailboxAddress.Parse("transportapigroup2@gmail.com"));
			blockedemail.To.Add(MailboxAddress.Parse(email));
			blockedemail.Subject = "Your Account Has Been Blocked";
			blockedemail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = $@"<!DOCTYPE html>
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">

<head>
	<title></title>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
	<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}

		body {{
			margin: 0;
			padding: 0;
		}}

		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}

		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}

		p {{
			line-height: inherit
		}}

		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}

		@media (max-width:520px) {{
			.desktop_hide table.icons-inner {{
				display: inline-block !important;
			}}

			.icons-inner {{
				text-align: center;
			}}

			.icons-inner td {{
				margin: 0 auto;
			}}

			.row-content {{
				width: 100% !important;
			}}

			.mobile_hide {{
				display: none;
			}}

			.stack .column {{
				width: 100%;
				display: block;
			}}

			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}

			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}

			.row-1 .column-1 {{
				padding: 10px 0 5px !important;
			}}
		}}
	</style>
</head>

<body style=""background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;"">
		<tbody>
			<tr>
				<td>
					<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f2f2f2;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/950030_934518/editor_images/108d1c95-e311-461e-8266-c0467af0c40e.png"" style=""display: block; height: auto; border: 0; width: 199px; max-width: 100%;"" width=""199""></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><meta />
<style>
  body {{
    font-family: Arial, sans-serif;
    font-size: 16px;
    line-height: 2;
    background-color: #f5f5f5;
  }}

  .container {{
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    text-align: left;
  }}

  h1 {{
    font-size: 28px;
    font-weight: bold;
    margin-top: 0;
    margin-bottom: 20px;
  }}

  p {{
    margin-top: 20px;
    margin-bottom: 30px;
  }}

  .button {{
    display: block;
    margin: 0 auto;
    padding: 10px 20px;
    background-color: #38BFA7;
    color: #fff;
    text-decoration: none;
    border-radius: 5px;
    box-shadow: 0 3px 0 #159089;
    transition: background-color 0.2s ease;
    margin-top: 30px;
    width: max;
    text-align: center;
  }}

  .button:hover {{
    background-color: #388e3c;
  }}
</style>

<div class=""container"">
  <h1> Your Account Has Been Blocked!</h1>
  <h3> Your account has been locked. Contact the relevant admin support to unlock it, then try again.</h3>
  <p> Email us at: transportapigroup2@gmail.com</p>
  <p>Best regards,<br />The Code Crusaders</p>
</div></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-3"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><div class=""our-class""> <p>
  
  
  </p> </div></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""icons_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""vertical-align: middle; color: #9d9d9d; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;"">
																<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																	<tr>
																		<td class=""alignment"" style=""vertical-align: middle; text-align: center;"">
																			<!--[if vml]><table align=""left"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;""><![endif]-->
																			<!--[if !vml]><!-->
																			<table class=""icons-inner"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
																				<!--<![endif]-->
																			</table>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>

</html>"
			};

			using var smtp = new SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate("transportapigroup2@gmail.com", "tbfpagdwhkksrhgf");
			smtp.Send(blockedemail);
			smtp.Disconnect(true);
		}

		// Need to input login link
		public void ForgetPasswordEmail(string email, string password)
		{
			var passwordemail = new MimeMessage();
			passwordemail.From.Add(MailboxAddress.Parse("transportapigroup2@gmail.com"));
			passwordemail.To.Add(MailboxAddress.Parse(email));
			passwordemail.Subject = "Reset Your Password";
			passwordemail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = $@"<!DOCTYPE html>
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">

<head>
	<title></title>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
	<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}

		body {{
			margin: 0;
			padding: 0;
		}}

		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}

		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}

		p {{
			line-height: inherit
		}}

		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}

		@media (max-width:520px) {{
			.desktop_hide table.icons-inner {{
				display: inline-block !important;
			}}

			.icons-inner {{
				text-align: center;
			}}

			.icons-inner td {{
				margin: 0 auto;
			}}

			.row-content {{
				width: 100% !important;
			}}

			.mobile_hide {{
				display: none;
			}}

			.stack .column {{
				width: 100%;
				display: block;
			}}

			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}

			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}

			.row-1 .column-1 {{
				padding: 10px 0 5px !important;
			}}
		}}
	</style>
</head>

<body style=""background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;"">
		<tbody>
			<tr>
				<td>
					<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f2f2f2;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/BeeFree/beefree-w69hi7ysblp/editor_images/4ddfa4c2-6886-4d8a-8f1f-6650f468359a.png"" style=""display: block; height: auto; border: 0; width: 200px; max-width: 100%;"" width=""200""></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><meta />
<style>
  body {{
    font-family: Arial, sans-serif;
    font-size: 16px;
    line-height: 2;
    background-color: #f5f5f5;
  }}

  .container {{
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    text-align: left;
  }}

  h1 {{
    font-size: 28px;
    font-weight: bold;
    margin-top: 0;
    margin-bottom: 20px;
  }}

  p {{
    margin-top: 20px;
    margin-bottom: 30px;
  }}

  .button {{
    display: block;
    margin: 0 auto;
    padding: 10px 20px;
    background-color: #38BFA7;
    color: #fff;
    text-decoration: none;
    border-radius: 5px;
    box-shadow: 0 3px 0 #159089;
    transition: background-color 0.2s ease;
    margin-top: 30px;
    width: max;
    text-align: center;
  }}

  .button:hover {{
    background-color: #388e3c;
  }}
</style>

<div class=""container"">
  <h3>It Seems You've Forgotten Your Password!</h3>
  <p> Dear User,</p>

  <p> You recently requested to reset your password for your account. To reset your password, please use the temporary password provided below to log in and change your password:
</p><p>{password}</p>
<br />
  <p> If you did not request a password reset, please ignore this email.</p>
  <br />
  <p>Best regards,<br />The Code Crusaders</p>
  <p>
    <a href=""#"" class=""button""> Reset Your Password </a>
  </p>
</div></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""icons_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""vertical-align: middle; color: #9d9d9d; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;"">
																<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																	<tr>
																		<td class=""alignment"" style=""vertical-align: middle; text-align: center;"">
																			<!--[if vml]><table align=""left"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;""><![endif]-->
																			<!--[if !vml]><!-->
																			<table class=""icons-inner"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
																				<!--<![endif]-->
																			</table>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>

</html>"
			};

			using var smtp = new SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate("transportapigroup2@gmail.com", "tbfpagdwhkksrhgf");
			smtp.Send(passwordemail);
			smtp.Disconnect(true);
		}

		// Need to input login link
		public void RegisteredEmail(string email)
		{
			var registeremail = new MimeMessage();
			registeremail.From.Add(MailboxAddress.Parse("transportapigroup2@gmail.com"));
			registeremail.To.Add(MailboxAddress.Parse(email));
			registeremail.Subject = "Account Has Been Created";
			registeremail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
                Text = $@"
<!DOCTYPE html>
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">

<head>
	<title></title>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
	<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}

		body {{
			margin: 0;
			padding: 0;
		}}

		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}

		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}

		p {{
			line-height: inherit
		}}

		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}

		@media (max-width:520px) {{
			.desktop_hide table.icons-inner {{
				display: inline-block !important;
			}}

			.icons-inner {{
				text-align: center;
			}}

			.icons-inner td {{
				margin: 0 auto;
			}}

			.row-content {{
				width: 100% !important;
			}}

			.mobile_hide {{
				display: none;
			}}

			.stack .column {{
				width: 100%;
				display: block;
			}}

			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}

			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}

			.row-1 .column-1 {{
				padding: 10px 0 5px !important;
			}}
		}}
	</style>
</head>

<body style=""background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;"">
		<tbody>
			<tr>
				<td>
					<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f2f2f2;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/BeeFree/beefree-w69hi7ysblp/editor_images/4ddfa4c2-6886-4d8a-8f1f-6650f468359a.png"" style=""display: block; height: auto; border: 0; width: 200px; max-width: 100%;"" width=""200""></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><meta />
<style>
  body {{
    font-family: Arial, sans-serif;
    font-size: 16px;
    line-height: 2;
    background-color: #f5f5f5;
  }}

  .container {{
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    text-align: left;
  }}

  h1 {{
    font-size: 28px;
    font-weight: bold;
    margin-top: 0;
    margin-bottom: 20px;
  }}

  p {{
    margin-top: 20px;
    margin-bottom: 30px;
  }}

  .button {{
    display: block;
    margin: 0 auto;
    padding: 10px 20px;
    background-color: #38BFA7;
    color: #fff;
    text-decoration: none;
    border-radius: 5px;
    box-shadow: 0 3px 0 #159089;
    transition: background-color 0.2s ease;
    margin-top: 30px;
    width: max;
    text-align: center;
  }}

  .button:hover {{
    background-color: #388e3c;
  }}
</style>

<div class=""container"">
  <h2>Your Transport Journey Begins Here!</h2>
  <p>Dear New User,</p>
  <p> Welcome to our transport app! Thank you for choosing to register with us. We hope you find our app useful in planning your travels. </p>
  <p> You can use our app to locate different bus and train schedules as well as to reserve a taxi at the touch of a button.</p>
  <p>We look forward to helping you with your travels!</p>
  <p>Best regards,<br />The Code Crusaders</p>
  <p>
    <a href=""#"" class=""button"">Get Started Now</a>
  </p>
</div></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-3"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><div class=""our-class""> <p>
  
  
  </p> </div></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""icons_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""vertical-align: middle; color: #9d9d9d; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;"">
																<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																	<tr>
																		<td class=""alignment"" style=""vertical-align: middle; text-align: center;"">
																			<!--[if vml]><table align=""left"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;""><![endif]-->
																			<!--[if !vml]><!-->
																			<table class=""icons-inner"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
																				<!--<![endif]-->
																			</table>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>

</html>"
            };

			using var smtp = new SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate("transportapigroup2@gmail.com", "tbfpagdwhkksrhgf");
			smtp.Send(registeremail);
			smtp.Disconnect(true);
		}

        public void UnblockedEmail(string email)
        {
            var unblockedemail = new MimeMessage();
            unblockedemail.From.Add(MailboxAddress.Parse("transportapigroup2@gmail.com"));
            unblockedemail.To.Add(MailboxAddress.Parse(email));
            unblockedemail.Subject = "Your Account Has Been Unblocked";
			unblockedemail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
                Text = $@"
<!DOCTYPE html>
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">
<head>
	<title></title>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
	<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}
		body {{
			margin: 0;
			padding: 0;
		}}
		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}
		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}
		p {{
			line-height: inherit
		}}
		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}
		@media (max-width:520px) {{
			.desktop_hide table.icons-inner {{
				display: inline-block !important;
			}}
			.icons-inner {{
				text-align: center;
			}}
			.icons-inner td {{
				margin: 0 auto;
			}}
			.row-content {{
				width: 100% !important;
			}}
			.mobile_hide {{
				display: none;
			}}
			.stack .column {{
				width: 100%;
				display: block;
			}}
			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}
			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}
			.row-1 .column-1 {{
				padding: 10px 0 5px !important;
			}}
		}}
	</style>
</head>
<body style=""background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;"">
		<tbody>
			<tr>
				<td>
					<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #F2F2F2;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/950030_934518/editor_images/108d1c95-e311-461e-8266-c0467af0c40e.png"" style=""display: block; height: auto; border: 0; width: 199px; max-width: 100%;"" width=""199""></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><meta />
<style>
  body {{
    font-family: Arial, sans-serif;
    font-size: 16px;
    line-height: 2;
    background-color: #F5F5F5;
  }}
  .container {{
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    text-align: left;
  }}
  h1 {{
    font-size: 28px;
    font-weight: bold;
    margin-top: 0;
    margin-bottom: 20px;
  }}
  p {{
    margin-top: 20px;
    margin-bottom: 30px;
  }}
  .button {{
    display: block;
    margin: 0 auto;
    padding: 10px 20px;
    background-color: #38BFA7;
    color: #fff;
    text-decoration: none;
    border-radius: 5px;
    box-shadow: 0 3px 0 #159089;
    transition: background-color 0.2s ease;
    margin-top: 30px;
    width: max;
    text-align: center;
  }}
  .button:hover {{
    background-color: #388E3C;
  }}
</style>
<div class=""container"">
  <p> We are pleased to inform you that your account has been successfully unblocked. You should now be able to access your account and use all of its features without any further issues.</p>
  <p>Thank you for your patience and understanding throughout this process. </p>
  <p>Best regards,<br />The Code Crusaders</p>
</div></div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-3"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;"" align=""center""><div class=""our-class""> <p>
  </p> </div></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;"" width=""500"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""icons_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""vertical-align: middle; color: #9D9D9D; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;"">
																<table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																	<tr>
																		<td class=""alignment"" style=""vertical-align: middle; text-align: center;"">
																			<!--[if vml]><table align=""left"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;""><![endif]-->
																			<!--[if !vml]><!-->
																			<table class=""icons-inner"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;"" cellpadding=""0"" cellspacing=""0"" role=""presentation"">
																				<!--<![endif]-->
																			</table>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>
</html>"
			};

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("transportapigroup2@gmail.com", "tbfpagdwhkksrhgf");
            smtp.Send(unblockedemail);
            smtp.Disconnect(true);
        }
    }
}
