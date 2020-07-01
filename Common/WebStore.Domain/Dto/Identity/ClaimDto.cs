using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Domain.Dto.Identity
{
	public class ClaimDto : UserDto
	{
		public IEnumerable<Claim> Claims { get; set; }
	}

	public class AddClaimsDto : ClaimDto
	{
	}

	public class RemoveClaimsDto : ClaimDto
	{
	}

	public class ReplaceClaimsDto : UserDto
	{
		public Claim Claim { get; set; }
		public Claim NewClaim { get; set; }
	}
}
