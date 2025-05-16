# 🧠Semantic Kernel Function Chaining Demo

This is a small proof-of-concept project that demonstrates **function calling and chaining** using [Semantic Kernel (SK)](https://github.com/microsoft/semantic-kernel) with the [`qwen3:8b`](https://ollama.com/library/qwen3:8b) model from Ollama.

## 🔧 Setup

Before running the application, make sure you have [Ollama](https://ollama.com) installed and the `qwen3:8b` model downloaded.

### Install and Run the Model

```bash
ollama run qwen3:8b
```

## ⚙️ Function Calling & Chaining

- Function calls are handled using Semantic Kernel
- This demo tests whether an LLM can understand and chain multiple operations in a single query
- Initially tested with llama3.2:3b, but qwen3:8b showed more reliable performance for chaining logic
