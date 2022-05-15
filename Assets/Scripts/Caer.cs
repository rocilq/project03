using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caer : MonoBehaviour
{
    [Header("Parametros Editables")]
    [SerializeField] private LayerMask sueloLayer;
    [SerializeField] private Transform poloTierra;

    #region Llamado_parametros
        private int CaerAnimationParameter = Animator.StringToHash("Falling");
        #endregion

        #region Componentes

        protected Rigidbody2D rb2D;

        protected Animator animator;

        #endregion

        #region Variables

        public bool CayendoAhora;

        public bool estaEnTierra;

        private float radius = 0.03f;

        #endregion

        void Start(){
            rb2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update(){
            LocalInput();
            validarCaida();
            SetAnimation();
        }

        void FixedUpdate(){

        }

        #region Metodos

        protected void LocalInput(){

        }

        protected void validarCaida(){
            if(SueloCollision())
                CayendoAhora = false;
            else
                CayendoAhora = true;
            
        }

        protected bool SueloCollision(){
            estaEnTierra = Physics2D.OverlapCircle(poloTierra.position, radius, sueloLayer); 
            if(estaEnTierra)
                return true;
            
            return false;
            
        }

        public void SetAnimation(){
            animator.SetBool(CaerAnimationParameter, CayendoAhora);
        }

        #endregion
}
