﻿namespace WebService.MvcUI.Areas.Admin.Models
{
  public class AccessTokenItem
  {
    public List<string> Claims { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
  }
}
