using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;



public class DateManager : MonoBehaviour
{
    public int time_1;
    public int time_2;
    public int time_3;

  
    public TextMeshProUGUI time_text_1;
    private bool tab_pop_bool;
    public int time;
    private SaveLoad saveload;
    public GameObject game_tab_pop;
    
    public GameObject game_1_btn;
    public GameObject game_2_btn;
    public GameObject game_3_btn;    
    public GameObject load_list_pop;

    public bool choise_game_1 = false;
    public bool choise_game_2 = false;
    public bool choise_game_3 = false;
    public int delete_game_num;
    public GameObject alert;
    public TextMeshProUGUI alert_text;

    public string comfirm_mode;
    public int now_game;
    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        //list_load();
    }
    IEnumerator time_coru()
    {
        if (saveload.now_game == 1)
        {
            if (saveload.time_1 >= 0)
                   saveload.time_1++;

            if (time_text_1 != null)
                time_text_1.text = ((saveload.time_1 / 14400) + 1) + "일차\n" + (saveload.time_1 / 600%24) + ":" + (saveload.time_1 / 60%60);
            
            else if (saveload.now_game == 2)
            {
                if (saveload.time_2 >= 0)
                {
                    saveload.time_2++;
                }
                time_text_1.text = ((saveload.time_2 / 14400) + 1) + "일차\n" + (saveload.time_2 / 600%24) + ":" + (saveload.time_2 / 60%60);

            }else if (saveload.now_game == 3)
            {
                if (saveload.time_3 >= 0)
                {
                    saveload.time_3++;
                }

                time_text_1.text = ((saveload.time_3 / 14400) + 1) + "일차\n" + (saveload.time_3 / 600 % 24) + ":" +
                                   (saveload.time_3 / 60 % 60);
            }
        }
      
        yield return new WaitForSeconds(1f/6f);
        StartCoroutine("time_coru", 1f/6f);
    }

    void Start()
    {
        tab_pop_bool = false;

        comfirm_mode = "";
        //list_load();
        StartCoroutine("time_coru", 1f/6f);
    }

    public void game_1_choise()
    {
        choise_game_1 = !choise_game_1;
        if (choise_game_1)
        {
            game_1_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
              game_1_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }
    
    public void game_2_choise()
    {
        choise_game_2 = !choise_game_2;
        if (choise_game_2)
        {
            game_2_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            game_2_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }
    
    public void game_3_choise()
    {
        choise_game_3 = !choise_game_3;
        if (choise_game_3)
        {
            game_3_btn.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            game_3_btn.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
    }


    public void delete_btn_click()
    {
        if (choise_game_1||choise_game_2||choise_game_3)
        {
            alert_text.text = "정말 삭제하시겠습니까?";
            alert.SetActive(true);
        }
    }
    
    public void GameStart()
    {
        if (saveload.time_1 != -1 && saveload.time_2 != -1  && saveload.time_3 != -1 )
        {
            saveload.time_1 = 0;
            saveload.now_game = 1;
        }
        else
        {
            if (saveload.time_1 == -1 && saveload.time_2 == -1 && saveload.time_3 == -1 ||
                saveload.time_1 == -1 && saveload.time_2 != -1 && saveload.time_3 != -1 ||
                saveload.time_1 == -1 && saveload.time_2 != -1 && saveload.time_3 == -1 )
            {
               
            }
            else if(saveload.time_1 != -1 && saveload.time_2 == -1 && saveload.time_3 != -1 ||
                     saveload.time_1 != -1 && saveload.time_2 != -1 && saveload.time_3 == -1 ||
                     saveload.time_1 != -1 && saveload.time_2 == -1 && saveload.time_3 == -1 )
            {
                saveload.time_2 = 0;
                saveload.now_game = 2;
              
            }
            else if(saveload.time_1 != -1 && saveload.time_2 != -1 && saveload.time_3 == -1 )
            {
                saveload.time_3 = 0;
                saveload.now_game = 3;
            }
        }
    }
    
    public void delete_mode()
    {
        comfirm_mode = "삭제";
    }
    
     
    public void visit_mode()
    {
        comfirm_mode = "입장";
    }
    public void delete_func()
    {
        if (choise_game_1)
        {
            saveload.time_1 = -1;
        }
        
        if(choise_game_2)
        {
            saveload.time_2 = -1;
        }
      
        if(choise_game_3)
        {
            saveload.time_3 = -1;
        }
        
        //list_load();
    }
   
    //public void list_load()
    //{
    //    if (saveload.time_1 == -1)
    //    {
    //        game_1_btn.GetComponent<Button>().interactable = false;
    //    }
    //    else
    //    {
    //        game_1_btn.GetComponent<Button>().interactable = true;
    //    }
        
    //    if (saveload.time_2 == -1)
    //    {
    //        game_2_btn.GetComponent<Button>().interactable = false;
    //    }
    //    else
    //    {
    //        game_2_btn.GetComponent<Button>().interactable = true;
    //    }
        
    //    if (saveload.time_3 == -1)
    //    {
    //        game_3_btn.GetComponent<Button>().interactable = false;
    //    }
    //    else
    //    {
    //        game_3_btn.GetComponent<Button>().interactable = true;
    //    }
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !tab_pop_bool)
        {
            game_tab_pop.SetActive(true);
            //list_load();
            tab_pop_bool = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && tab_pop_bool)
        {
            game_tab_pop.SetActive(false);
            tab_pop_bool = false;
        }
    }
    

}
