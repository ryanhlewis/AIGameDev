# AI In Game Dev

We see AI models like ChatGPT, Stable Diffusion, Dall-E, etc. everywhere. 
How can we use them to make our lives easier and our game development process faster?

We'll look at three things this tutorial: generative NPC dialogue, generative textures, and auto 3D texturing.
All of this is newly possible because of the advancements made within the last year.

Let's get started.

## Generative Dialogue

First, we'll need to install an "API" so our Unity game can send requests to ChatGPT.
While ChatGPT does, as of February, have an "official API", I wrote this tutorial before they did.

You can choose to use the "unofficial API" for educational purposes, but if you do plan on commercially releasing
any games with this technology, please use their official API to escape any legal complications.

Download the unofficial API from https://github.com/ryanhlewis/chatgpt-unofficial-api
(I don't claim this is my work, I just fixed some of it so it works)

Extract it to a directory, and now open a command prompt and run the following commands:

```
cd {PATH OF chatgpt-unofficial-api FOLDER}
pip install playwright
pip install -r requirements.txt
python server.py
```

The program will prompt you to login to your OpenAI account, and once done, simply run

```
python server.py
```

And now we should have an API at localhost:5000!

Now, let's give it a prompt. The endpoint looks like:

```
http://localhost:5000/chat?q={INSERT YOUR REQUEST HERE}
```

So, we can plug in a simple sentence to get the dialogue started!

```
http://localhost:5000/chat?q=Pretend you are a hopeless frog,  standing on a bridge%20when%20adventurers%20pass%20you%20by.%20Ribbit%20them%20some%20despair!
```

And we get back:
```
Ribbit ribbit, oh weary travelers passing by. Do you see me here, this hopeless frog on this bridge so high? I once dreamed of leaping through the greenery, but now I'm stuck in this mundane scenery. Oh, to be a brave adventurer like you, with tales of glory and deeds so true. But here I am, just a lowly amphibian, with no great quest or adventure to begin. I envy your strength, your courage, your might. For I am just a frog, lost in the night. So go on, dear travelers, and leave me be. Ribbit ribbit, forlorn and alone on this bridge, that's me.
```

NOTE! The length of time it takes for ChatGPT to respond is directly correlated to how long its message is. Plan this out if you want to have interactive 
dialogue! You might need to generate a longer message a few messages earlier to maintain pacing.

Hopping into Unity, let's actually make this API queriable as a dialogue system.

