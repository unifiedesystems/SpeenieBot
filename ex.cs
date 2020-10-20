       else if ((message.Text == "/setradius"))
                {
                    try
                    {
                        if (usessions.ContainsKey(message.Chat.Id) == false)
                        {
                            int u = usessions.Count;
                            usessions.Add(message.Chat.Id, u);
                            SetDefault(u);
                        }
                        bool issent = false;
                        int rtr = 0;
                        while ((issent == false) && (rtr < 5))
                        {
                            try
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Send new radius in meters between 1000 m and 1000000 m (for example 3000)");
                                issent = true;
                            }
                            catch (Exception e) { issent = false; rtr++; }
                        }
                        upresets[(int)usessions[message.Chat.Id], 3] = 1;

                    }
                    catch (Exception e) { Console.WriteLine("setradius command processing error" + Environment.NewLine + e.Message.ToString()); }
                }
				
				 else if ((message.Text.Contains("getattractor ")))
                {
                    try
                    {
                        if (usessions.ContainsKey(message.Chat.Id) == false)
                        {
                            int u = usessions.Count;
                            usessions.Add(message.Chat.Id, u);
                            SetDefault(u);
                        }
                        string nr = message.Text;
                        string nrd = @"/getattractor ";
                        nr = nr.Replace(nrd, "");
                        int tmprad = 3000;
                        if (Int32.TryParse(nr, out tmprad))
                        {
                            if (tmprad > 1000000) { try { await Bot.SendTextMessageAsync(message.Chat.Id, "Maximum radius is 1000000 m"); } catch (Exception ex) { } }
                            else
                            {
                                {
                                    bool issent = false;
                                    int rtr = 0;
                                    while ((issent == false) && (rtr < 5))
                                    {
                                        try
                                        {
                                            await Bot.SendTextMessageAsync(message.Chat.Id, "Radius changed to " + tmprad.ToString() + Environment.NewLine);
                                            issent = true;
                                        }
                                        catch (Exception e) { issent = false; rtr++; }
                                    }
                                }

                            }

                        }
                        else { try { await Bot.SendTextMessageAsync(message.Chat.Id, "Incorrect value."); } catch (Exception ex) { } }
                        //logging 
                        string buf1 = "";
                        if (message.From.FirstName != null) { buf1 = message.From.FirstName.ToString() + " "; }
                        if (message.From.LastName != null) { buf1 += message.From.FirstName.ToString() + " "; }
                        if (message.From.Username != null) { buf1 += " (" + message.From.Username.ToString() + ") "; }

                        System.IO.File.AppendAllText(logpath, message.Date.ToString() + " " + message.From.Id.ToString() + " " + buf1
                               + "changed radius: " + tmprad.ToString() + Environment.NewLine);
                        //logging
                    }
                    catch (Exception e) { Console.WriteLine("radius setting error " + Environment.NewLine + e.Message.ToString()); }
                }
                