<template>
<body class="bg-white">
<div class="flex min-h-screen">
  <div class="flex flex-row w-full">
    <div class='hidden lg:flex flex-col justify-between bg-[#61ff5c] lg:p-8 xl:p-12 lg:max-w-sm xl:max-w-lg'>
      <div class="flex items-center justify-start space-x-3">
        <a href="/" class="flex items-center">
            <span class="self-center text-2xl font-semibold whitespace-nowrap dark:text-white">Codar.Academy</span>
        </a>
      </div>
      <div class='space-y-5'>
        <h1 class="lg:text-3xl xl:text-5xl xl:leading-snug text-white font-extrabold">Entre na sua conta e descubra novos
            experiências</h1>
        <p class="text-lg text-white">Você não tem uma conta?</p>
        <button
          class="inline-block flex-none px-4 py-3 border-2 rounded-lg font-medium
           border-black bg-black text-white">Criar conta aqui</button>
      </div>
      <p class="font-medium text-white">© 2023 Codar.academy</p>
    </div>

    <!-- Login -->
    <div class="flex flex-1 flex-col items-center justify-center px-10 relative bg-white">
      <div class="flex lg:hidden justify-between items-center w-full py-4">
        <div class="flex items-center justify-start space-x-3">
          <span class="bg-black rounded-full w-6 h-6"></span>
          <a href="#" class="font-medium text-lg">Brand</a>
        </div>
      </div>
      <!-- Login box -->
      <div class="flex flex-1 flex-col justify-center space-y-5 max-w-m">
        <div class="flex flex-col space-y-2 text-center">
          <h2 class="text-3xl md:text-4xl font-bold text-black">Entrar na conta</h2>
          <p class="text-md md:text-xl">Entre no seu painel de aluno</p>
        </div>
        <div class="flex flex-col max-w-md space-y-5">
            <input
            type="text"
            placeholder="E-mail"
            class="flex px-3 py-2 md:px-4 md:py-3 border-2 border-black rounded-lg font-medium placeholder:font-normal bg-white"
          />
          <input
            type="text"
            placeholder="Senha"
            class="flex px-3 py-2 md:px-4 md:py-3 border-2 border-black rounded-lg font-medium placeholder:font-normal bg-white"
          />
          <button class="flex items-center justify-center flex-none px-3 py-2 md:px-4 md:py-3 border-2 rounded-lg font-medium border-black bg-black text-white">Entrar...</button>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- Example -->
</body>
</template>
