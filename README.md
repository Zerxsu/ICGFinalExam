# ICGFinalExam
My ID ended with an even number so I was tasked to graphically enhance Yoshi's Safari using my knowledge of shaders and VFX. I'll start by talking about the shaders implement, the logic behind how each shader works, then why I added it.

##Original Image  

![YoshiGame Snip](https://github.com/user-attachments/assets/85b10d04-e9df-4a63-b8ee-7a3c3af3e366)

# Shaders

### **Rimlighting Shader**  
**Logic:**  This shader creates a rim lighting effect similar to the previous one but with a more intense and customizable glow. The surf function calculates the rim lighting by first computing the dot product between the normalized view direction and the surface normal, then applying a saturate to ensure the result is within a 0 to 1 range. Instead of a simple linear emission, the result is raised to the power of _RimPower, which increases the contrast and intensity of the rim light at glancing angles, making the effect stronger and more visually prominent.

**Reason for Implementation:**  I created this because in the image Yoshi actually has an outline on his whole body and it looks like a gradiant towards the center pieces which suits rimlighting perfectly. It captures exactly how yoshi looks in the game while making it more modernized.  

![Yoshi Snip](https://github.com/user-attachments/assets/f6d3f9d9-0d02-4777-875f-acb2f47c3a82)

### **Scrolling Texture Shader**:  
**Logic:**  The scrolling shader can simulate water and flat ground with animated waves and normal mapping for enhanced surface detail. The vertex shader displaces the textures surface along the y-axis based on sine and cosine functions, creating waves that move over time. It also calculates the world position and normal for accurate lighting interaction. The fragment shader handles normal mapping by scrolling the UV coordinates to create the effect of moving moving textures as well as water. It then combines the normal map with the vertex normal and computes basic diffuse lighting using the light direction. The final color includes the diffuse lighting and the specified water color. This shader is designed for transparent water surfaces with a realistic wave effect as well as a base ground texture.  

**Reason for Implementation:**  So looking at the game it said I had to add a scrolling texture. I knew I wanted to add a flat ground but also water. So I gave myself the options to have all the adjustable parameters in one spot so I could simulate real water as well as a flat scrolling ground texture. It looks identical to the game screenshot and I'm happy with the end result

### **Lambert Shader**:  
**Logic:**  This standard Lambert shader calculates diffuse lighting by using the Lambertian reflection model. In the vertex function, the normal is transformed and normalized, and the direction of the light source is computed. The diffuse reflection is calculated by taking the dot product of the normal and light direction, then scaling it by the light color and the object's color (_Color). The fragment function simply outputs the calculated color for each pixel.

**Reason for Implementation:**  I needed a standard shader with decent shadows and color to apply to the pillars in the middle of the water, and I felt the Lambert shader suited the job perfectly. It definitetly modernizes the view by making the shadows pop.  

![Lambert Shader snip](https://github.com/user-attachments/assets/9f259af0-a241-4724-8102-64c7e9fedd7b)

### **Specular Shader**:  
**Logic:**  The Specular Shader calculates both diffuse and specular reflections for a surface under lighting conditions. It uses a color (_Color) and a specular color (_SpecColor) as properties, as well as a shininess factor (_Shininess) to control the sharpness of the specular highlight. In the vertex shader (vert), the world position and normalized normal direction are calculated for each vertex, transforming the vertex position to camera space for rendering. The fragment shader (frag) computes the lighting model. It starts by calculating the diffuse reflection using the Lambertian reflection model, based on the surface normal and light direction. The specular reflection is then computed using the Phong model, which reflects the light direction off the surface normal and compares it to the view direction (camera direction). The shininess value controls the sharpness of the specular highlight. Finally, the total light contribution is the sum of diffuse and specular reflections, combined with ambient light, and multiplied by the surface color. This results in the final color output.

**Reason for Implementation:**  I added this because coins are metal and metal always has a shine to it. I wanted the coins to have a shine to make them feel like genuine coins rather than giving them a flat color.  

![Coin specular Snip](https://github.com/user-attachments/assets/596354c6-108d-4445-96e2-111a78e7e15c)

### **ColorGrading Shader**:  
**Logic:**  This Color Grading Shader applies a Look-Up Table (LUT) to the main camera's texture to modify the colors of the rendered scene. The shader includes a texture for the scene (_MainTex) and a LUT texture (_LUT) for color transformation. The vertex shader processes the vertices and passes UV coordinates to the fragment shader. The fragment shader samples the original scene's colors and then maps them to the LUT based on their RGB values. The final color is a blend between the original color and the LUT-modified color, controlled by the _Contribution parameter, allowing for adjustable intensity of the color grading effect.

**Reason for Implementation:**  I added this because it was part of the requirements and looking at the game, everything has flat colours with no color grading. I got the vibe hat since Yoshi is for the most part always in bright areas, I might try adding a very subtle yellow tint to replicate the suns beams in a way.  

![Colorgrading Snip](https://github.com/user-attachments/assets/9b8af289-9dd8-47cd-8efb-0fb4718500db)
