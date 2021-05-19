<template>
  <div class="about" id="about">
    <div class="container-fluid">
      <h1 class="text-center">WE ARE <span>DIGIDINOS</span></h1>
      <div class="d-flex justify-content-around">
        <!-- Section 1 -->
        <div class="container">
          <div class="d-flex">
            <div class="icon-border">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                fill="white"
                class="bi bi-archive"
                viewBox="0 0 16 16"
              >
                <path
                  d="M0 2a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1v7.5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 12.5V5a1 1 0 0 1-1-1V2zm2 3v7.5A1.5 1.5 0 0 0 3.5 14h9a1.5 1.5 0 0 0 1.5-1.5V5H2zm13-3H1v2h14V2zM5 7.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5z"
                />
              </svg>
            </div>
            <h3 class="mt-4 whitetext">LOREM IPSUM</h3>
          </div>
          <div class="content whitetext">
            Lorem ipsum dolor sit amet consectetur adipiscing elit arcu, fames
            non aenean himenaeos lectus torquent elementum pellentesque
            nascetur, magna eu nisi lobortis lacinia velit molestie.
          </div>
        </div>

        <!-- Section 2 -->
        <div class="container">
          <div class="d-flex">
            <div class="icon-border">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                fill="white"
                class="bi bi-alarm"
                viewBox="0 0 16 16"
              >
                <path
                  d="M8.5 5.5a.5.5 0 0 0-1 0v3.362l-1.429 2.38a.5.5 0 1 0 .858.515l1.5-2.5A.5.5 0 0 0 8.5 9V5.5z"
                />
                <path
                  d="M6.5 0a.5.5 0 0 0 0 1H7v1.07a7.001 7.001 0 0 0-3.273 12.474l-.602.602a.5.5 0 0 0 .707.708l.746-.746A6.97 6.97 0 0 0 8 16a6.97 6.97 0 0 0 3.422-.892l.746.746a.5.5 0 0 0 .707-.708l-.601-.602A7.001 7.001 0 0 0 9 2.07V1h.5a.5.5 0 0 0 0-1h-3zm1.038 3.018a6.093 6.093 0 0 1 .924 0 6 6 0 1 1-.924 0zM0 3.5c0 .753.333 1.429.86 1.887A8.035 8.035 0 0 1 4.387 1.86 2.5 2.5 0 0 0 0 3.5zM13.5 1c-.753 0-1.429.333-1.887.86a8.035 8.035 0 0 1 3.527 3.527A2.5 2.5 0 0 0 13.5 1z"
                />
              </svg>
            </div>
            <h3 class="mt-4 whitetext">LOREM IPSUM</h3>
          </div>
          <div class="content whitetext">
            Lorem ipsum dolor sit amet consectetur adipiscing elit arcu, fames
            non aenean himenaeos lectus torquent elementum pellentesque
            nascetur, magna eu nisi lobortis lacinia velit molestie.
          </div>
        </div>

        <!-- Section 3 -->
        <div class="container">
          <div class="d-flex">
            <div class="icon-border">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                fill="white"
                class="bi bi-award"
                viewBox="0 0 16 16"
              >
                <path
                  d="M9.669.864L8 0 6.331.864l-1.858.282-.842 1.68-1.337 1.32L2.6 6l-.306 1.854 1.337 1.32.842 1.68 1.858.282L8 12l1.669-.864 1.858-.282.842-1.68 1.337-1.32L13.4 6l.306-1.854-1.337-1.32-.842-1.68L9.669.864zm1.196 1.193l.684 1.365 1.086 1.072L12.387 6l.248 1.506-1.086 1.072-.684 1.365-1.51.229L8 10.874l-1.355-.702-1.51-.229-.684-1.365-1.086-1.072L3.614 6l-.25-1.506 1.087-1.072.684-1.365 1.51-.229L8 1.126l1.356.702 1.509.229z"
                />
                <path
                  d="M4 11.794V16l4-1 4 1v-4.206l-2.018.306L8 13.126 6.018 12.1 4 11.794z"
                />
              </svg>
            </div>
            <h3 class="mt-4 whitetext">LOREM IPSUM</h3>
          </div>
          <div class="content whitetext">
            Lorem ipsum dolor sit amet consectetur adipiscing elit arcu, fames
            non aenean himenaeos lectus torquent elementum pellentesque
            nascetur, magna eu nisi lobortis lacinia velit molestie.
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.about {
  margin: 4em 0;
  position: relative;
}

.about h1 {
  color: white;
  margin-top: 2em;
  margin-bottom: 2em;
}

.about h1 span {
  color: #28a7e9;
}

.about svg {
  margin-top: 20px;
}

.about .container-fluid {
  padding-left: 5%;
  padding-right: 5%;
}

.about .container {
  width: 400px;
  height: 100px;
}

.about .icon-border {
  border: 2px solid #fff;
  border-radius: 2px;
  width: 80px;
  height: 80px;
  text-align: center;
  margin-right: 20px;
  margin-bottom: 20px;
}

.about .whitetext {
  color: white;
}

.about .content {
  margin-left: 100px;
}
</style>