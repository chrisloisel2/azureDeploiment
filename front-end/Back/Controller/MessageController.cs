using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/message")]
[ApiController]
public class messageController : ControllerBase
{
	// Creation d'une liste de message qui sera utilisé comme une base de donnée
	private static List<Message> _messages = new List<Message>()
	{
		new Message() { Id = 1, Text = "Hello" },
		new Message() { Id = 2, Text = "World" },
		new Message() { Id = 3, Text = "!" },
	};

	// Constructeur de ma classe
	public messageController()
	{
	}

	// GET: api/message
	[HttpGet]
	public ActionResult<IEnumerable<Message>> Getmessages()
	{
		// Retourne la liste des messages
		return Ok(_messages.ToList());
	}

	// GET: api/message/5
	[HttpGet("{id}")]
	public  ActionResult<Message> Getmessage(int id)
	{
		// Retourne le message qui a l'id passé en parametre
		// La methode FirstOrDefault retourne le premier element de la liste qui correspond à la condition
		var message = _messages.FirstOrDefault(x => x.Id == id);
		return message;
	}

	// PUT: api/message/5
	[HttpPut("{id}")]
	public  IActionResult Putmessage(int id, Message message)
	{
		// Si l'id passé en parametre est different de l'id du message je retourne une erreur
		if (id != message.Id)
		{
			return BadRequest();
		}

		// Je parcours la liste des messages, si l'id du message correspond à l'id passé en parametre je modifie le message
		_messages.ToList().ForEach(x =>
		{
			if (x.Id == id)
			{
				x.Text = message.Text;
			}
		});
		// Je retourne le message modifié pour valider la modification
		return Ok(message);
	}

	// POST: api/message
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	public  ActionResult<Message> Postmessage(Message message)
	{
		// J'ajoute le message à la liste des messages
		_messages.Add(message);
		return (message);
	}

	// DELETE: api/message/5
	[HttpDelete("{id}")]
	public  IActionResult Deletemessage(int id)
	{
		// Je recupere le message qui a l'id passé en parametre
		// La methode FirstOrDefault retourne le premier element de la liste qui correspond à la condition
		var message = _messages.FirstOrDefault(x => x.Id == id);

		// Si le message est null je retourne une erreur
		if (message == null)
		{
			return NotFound();
		}

		// Je supprime le message de la liste des messages en utilisant la methode where
		// La methode Where retourne une liste de message qui correspond à la condition
		// Elle renvoi donc les messages qui ont un id different de l'id passé en parametre
		_messages = _messages.Where(x => x.Id != id).ToList();
		return Ok();
	}
}
